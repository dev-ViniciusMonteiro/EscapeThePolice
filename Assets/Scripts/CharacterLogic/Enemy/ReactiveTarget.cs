using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Reactive Target")]
public class ReactiveTarget : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private CharacterController _character;
    private PlayerCharacter _player;
    private EnemyController _enemy;

    private Collider[] _withinAggroColliders;

    private readonly int _maxColliders = 4;
    private float _currentHealth;

    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _maxHealth;
    [SerializeField] private LayerMask _aggroLayerMask;

    public bool IsAlive { get; set; }
    public bool PlayerIsDetected { get; set; }

    public event Action<float> OnHealthPictureChanged = delegate { };

    void Start()
    {
        _enemy = GameObject.Find("EnemySpawner").GetComponent<EnemyController>();
        _navAgent = GetComponent<NavMeshAgent>();
        _withinAggroColliders = new Collider[_maxColliders];
        _character = GetComponent<CharacterController>();
    }
    
    private void OnEnable()
    {
        this._currentHealth = 5;
        IsAlive = true;
        PlayerIsDetected = false;
    }


    private void FixedUpdate()
    {
        if (IsAlive)
        {
            if (Physics.OverlapSphereNonAlloc(this.gameObject.transform.position, _detectionRadius,
                _withinAggroColliders,
                _aggroLayerMask) > 0)
            {
                PlayerIsDetected = true;
                ChasePlayer(_withinAggroColliders[0].GetComponent<PlayerCharacter>());
            }
            else
            {
                PlayerIsDetected = false;
            }
        }
        else
        {
            _navAgent.SetDestination(gameObject.transform.position);
        }
        
    }

    

    public void ReactToHit(int damage)
    {
        _currentHealth -= damage;
        
        float currentHealthPicture = (float) _currentHealth / (float) _maxHealth;
        OnHealthPictureChanged(currentHealthPicture);

        if (_currentHealth <= 0.0f)
        {
            IsAlive = false;
            StartCoroutine(Die());
            return;
        }

        Debug.Log($"Enemy Health is damaged at {damage}. Now {_currentHealth}");
    }

    private void ChasePlayer(PlayerCharacter player)
    {
        _player = player;
        _navAgent.SetDestination(player.transform.position);
    }
    
     IEnumerator Die()
    {
        yield return new WaitForSeconds(1.75f);
        _enemy._numberOfKilled++;
        Destroy(this.gameObject);
    }

    
}