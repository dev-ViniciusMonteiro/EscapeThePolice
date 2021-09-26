using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] 
[AddComponentMenu("Control Script/FPS Input")] 
public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    private CharacterController _characterController;
    private float deltaX,deltaZ;
    private float gravidade = -9.8f;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
       deltaX = Input.GetAxis("Horizontal")*speed;
        deltaZ = Input.GetAxis("Vertical")*speed;
        var movement = new Vector3(deltaX,0,deltaZ);
        //diagonal limite
        movement = Vector3.ClampMagnitude(movement, speed); 
        movement.y = gravidade;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement); 
    }

}
