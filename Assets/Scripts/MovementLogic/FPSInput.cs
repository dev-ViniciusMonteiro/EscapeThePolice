using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] 
[AddComponentMenu("Control Script/FPS Input")] 
public class FPSInput : MonoBehaviour
{
    private CharacterController _characterController;
    
    [SerializeField] private float speed = 6.0f;

    private float deltaX;
    private float deltaZ;
    private float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }
    void Move()
    {
        //initialising delta (steps) from player`s keyboard input ("Horizontal" - A/D or </> keys; "Vertical" - W/D or  up/down arrows)
        deltaX = Input.GetAxis("Horizontal")*speed;
        deltaZ = Input.GetAxis("Vertical")*speed;
        
        
        var movement = new Vector3(deltaX,0,deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed); //limiting diagonal speed
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement); //using this we forbid a player (character) to pass through the obstacles
    }
}
