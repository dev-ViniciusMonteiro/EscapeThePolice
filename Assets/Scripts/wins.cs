using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wins : MonoBehaviour
{
    
 void OnTriggerStay(Collider target)
 {
     if(target.tag == "Player")
     {
         SceneManager.LoadScene(0);
     }
 }
}