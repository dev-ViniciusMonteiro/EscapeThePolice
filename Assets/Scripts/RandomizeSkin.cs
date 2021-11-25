using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSkin : MonoBehaviour
{

    //recebe as skins de zombie e escolhe qual sera utilizada alheatoriamente
    public List<GameObject> zombieSkins = new List<GameObject>();
    private int n;
    private void Awake()
    {
        n = Random.Range(0, zombieSkins.Count - 1);    
    }

    private void Start()
    {
        //varre as skins escondendo todas
        foreach (var skin in zombieSkins)
        {
            skin.gameObject.SetActive(false);
        }
        //seta a skin no numero randomico
        zombieSkins[n].SetActive(true);
    }
}
