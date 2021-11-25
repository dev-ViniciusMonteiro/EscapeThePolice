using System.Collections;
using UnityEngine;

//referencia: https://www.alura.com.br/curso-online-criacao-de-jogos-com-unity
public class Target : MonoBehaviour
{
    public int health;
    public float damage;
    public float speed;
    public Animator _anim;
    public AudioSource _audio;
    public AudioClip _receiveDamage;
    public bool _isDead = false;
    protected bool _isReceivingDamage = false;
	public float timeToDie;
    public float invulnerabilityTime = 1;

    private void Awake()
    {
        //instancia a animacao
        _anim = GetComponent<Animator>();
    }


    public virtual void TakeDamage(int amount)
    {
        //se tiver vida vai tirando e colocando audio
         if (health > 0)
         {
             health -= amount;
             if(_audio != null)
             {
             	_audio.PlayOneShot(_receiveDamage);
             }
             if(_anim != null)
             {
                StartCoroutine(StunCorroutine());
             }
         }
        //caso nao tenha vida
         if (health <= 0)
         {
            Die();  
         }
    }
    //seta animacao de morto, coloca chave de morto e destroi tudo
    void Die()
    {
        _anim.SetBool("IsDead", true);
        _isDead = true;
        Destroy(gameObject, timeToDie);
    }

//colisao para o hit
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerStats>())
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            other.gameObject.GetComponent<PlayerStats>().hitPlayer = true;
        }
    }

//corrotina de fazer o zombie ter hit
    IEnumerator StunCorroutine()
    {
        speed = 0;
        _anim.Play("ZombieHit", 0, 0);
        yield return new WaitForSeconds(_anim.GetCurrentAnimatorClipInfo(0).Length);
        speed = .5f;
    }
}
