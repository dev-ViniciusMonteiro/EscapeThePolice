using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	[Range(5, 100)]
	//Depois de quanto tempo a pré-fabricada bala deve ser destruída? 
	public float destroyAfter;
	//Se habilitado, a bala destrói com o impacto 
	public bool destroyOnImpact = false;
	//Tempo mínimo após o impacto que a bala é destruída 
	public float minDestroyTime;
	//Tempo máximo após o impacto em que a bala é destruída
	public float maxDestroyTime;

	//prefabe de impacto com efeito
	//era pra ser bonitinho em cada testura mas nao tive tempo
	public Transform[] bloodImpactPrefabs;
	public Transform[] metalImpactPrefabs;
	public Transform[] dirtImpactPrefabs;
	public Transform[] concreteImpactPrefabs;

	public int damage = 20;
	public float speed = 5;

	private void Start()
	{
		//inicia tempo de detruicao
		StartCoroutine(DestroyAfter());
	}

    
    private void OnCollisionEnter(Collision collision)
    {
		//se for no player
		if (collision.gameObject.tag == "Player")
		{	//ignora
			Physics.IgnoreCollision(collision.collider, GetComponent<SphereCollider>(), true);
		}
		//para inimigo
		if (collision.gameObject.tag == "Enemy")
        {
			Instantiate(bloodImpactPrefabs[Random.Range(0, bloodImpactPrefabs.Length)], transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
			//o C de ivulnerabilidade iria funcionar aqui mas F
			/*if (collision.gameObject.GetComponent<Target>().invulnerabilityTime <= 0)
            {
				collision.transform.GetComponent<Target>().TakeDamage(damage);
				//cara congelou cena mas achei desnessario

            }*/
			Destroy(gameObject);			
		}
		//se nao destruiu
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
		//randomico com minimo e maximo
		yield return new WaitForSeconds
			(Random.Range(minDestroyTime, maxDestroyTime));
		//Destroy municao
		Destroy(gameObject);
	}

	private IEnumerator DestroyAfter()
	{
		yield return new WaitForSeconds(destroyAfter);
		Destroy(gameObject);
	}

	private IEnumerator ChangeConstrains()
	{
		yield return new WaitForSeconds(.5f);
	}
}
