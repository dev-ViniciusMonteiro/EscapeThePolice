using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gatilhos do playes 
public class PlayerTriggers : MonoBehaviour
{
    public bool haveMap;
    public bool haveCode;
    [SerializeField] private GameObject noCodeText;
    private void OnTriggerExit(Collider other)
    {//colisao fianl do mapa
        if (other.gameObject.tag == "Mapa")
        {
            haveMap = true;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {//colisao ao bater com tag code
        if (other.gameObject.tag == "Code")
        {
            haveCode = true;
        }
       
    }

    private void OnTriggerStay(Collider other)
    {//
        if (other.gameObject.tag == "FinalDoor")
        {
            if (!haveCode)
            {//colisao ao sair do finaldoor
                noCodeText.SetActive(true);
            }
        }
    }
}
