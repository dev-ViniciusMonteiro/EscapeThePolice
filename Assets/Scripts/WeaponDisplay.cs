using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//para mudar arma de mao
public class WeaponDisplay : MonoBehaviour
{
    //https://docs.unity3d.com/ScriptReference/Transform.html
    public Transform ak, handGun;
    public bool isAK;
    [SerializeField] private Image primaryWeapon, secondaryWeapon;

    private void Start()
    {
        //inicia com ar, por isso rola a animacao no comeco e nao ja entra com a animacao
        isAK = true;
        GetComponent<FPSController>().arms = ak;
    }

    private void Update()
    {

        //se aperta 2 e ta sem pistola na mao
         if (Input.GetKeyDown(KeyCode.Alpha2) && handGun.gameObject.activeInHierarchy == false)
        {
            //tira a ak do bool
            isAK = false;
            //ativa a pt
            handGun.gameObject.SetActive(true);
            //add a pistola no jogador
            GetComponent<FPSController>().arms = handGun;
            //delay
            StartCoroutine(changeWeapon());
            //tira ak
            ak.gameObject.SetActive(false);

        }

//se aperta 1 e esta sem ak na mao
        if (Input.GetKeyDown(KeyCode.Alpha1) && ak.gameObject.activeInHierarchy == false)
        {
            isAK = true;
            ak.gameObject.SetActive(true);
            GetComponent<FPSController>().arms = ak;
            StartCoroutine(changeWeapon());
            handGun.gameObject.SetActive(false);
        }
        
       
//seta visao das armas
        if (isAK)
        {
            primaryWeapon.gameObject.SetActive(true);
            secondaryWeapon.gameObject.SetActive(false);
        }

        else
        {
            secondaryWeapon.gameObject.SetActive(true);
            primaryWeapon.gameObject.SetActive(false);
        }
    }

    IEnumerator changeWeapon()
    {
        //delay
        yield return new WaitForSeconds(.25f);
    }
}
