using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _obstacleRange;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float reloadTime = 2f;

    private ReactiveTarget _target;
    private GameObject _bullet;
    private Ray _ray;
    private bool _isReloading;


    private void Start()
    {
        _target = GetComponent<ReactiveTarget>();
        _isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }

    void Wander()
    {
        if (_target.IsAlive && !_target.PlayerIsDetected)
        {
            StartMove();
        }
        else if (!_target.IsAlive || _target.PlayerIsDetected)
        {
            StopMove();
        }

        Observe();
    }

    void StartMove()
    {
        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    void StopMove()
    {
        transform.Translate(0, 0, 0);
    }

    void Observe()
    {
        _ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(_ray, 0.25f, out hit) && _target.IsAlive && !_isReloading)
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                _bullet = Instantiate(_bulletPrefab) as GameObject;
                _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                _bullet.transform.rotation = transform.rotation;
                StartCoroutine(Reload());
            }

            else if (hit.distance < _obstacleRange)
            {
                var angle = Random.Range(-120, 120);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    IEnumerator Reload()
    {
        _isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        _isReloading = false;
    }
}