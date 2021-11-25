using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//era pra ser um mapa mas nao deu tempo de terminar :)
public class WorldSpaceCanvas : MonoBehaviour
{
    private FPSController player;
    private float rotationSpeed = 20;
    private void Start()
    {
        player = FindObjectOfType<FPSController>();
    }

    private void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
            //transform.RotateAround(player.transform.position, Vector3.up, Time.deltaTime * rotationSpeed);
        }
        else
        {
            return;
        }
    }
}
