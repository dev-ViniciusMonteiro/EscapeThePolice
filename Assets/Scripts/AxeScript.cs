using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=PxdoBJBCcrw
//no site dele ele explica melhor https://obalfaqih.com/
public class AxeScript : MonoBehaviour
{
    public float rotationSpeed;
    public float _speed;
    public float damage;
    private AudioSource _audio;
    [SerializeField] private GameObject renderAxe;
    [SerializeField] private AudioClip axeSound;

    [Range(5, 100)]
    //Depois de quanto tempo o pré-fabricado com bala deve ser destruído?"
    public float destroyAfter;
    //Se habilitado, a bala destrói no impacto
    public bool destroyOnImpact = false;
    //Tempo mínimo após o impacto que a bala é destruída
    public float minDestroyTime;
    //Tempo máximo após o impacto em que a bala é destruída
    public float maxDestroyTime;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audio.PlayOneShot(axeSound);
    }
    void Update()
    {
        renderAxe.transform.Rotate(rotationSpeed, 0, 0);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //dano jogador
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStats>().SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
        else
        {
            //destroir dps
            if (!destroyOnImpact)
            {
                StartCoroutine(DestroyTimer());
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //impacto com obj
        if (!destroyOnImpact)
        {
            StartCoroutine(DestroyTimer());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyTimer()
    {
        //tempo para destruir
        yield return new WaitForSeconds
            (Random.Range(minDestroyTime, maxDestroyTime));
        Destroy(gameObject);
    }
}
