﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{//incializa
    [SerializeField]
    private float _moveSpeed = 5;
    [SerializeField]
    private float _runningSpeed = 9;
    [SerializeField]
    public float _gravity = -10;
    [SerializeField]
    private float _jumpHeight = 3;
    [SerializeField]
    private float _groundDistance = .5f;

    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _groundMask;

   [SerializeField]
   private Transform arms;
   [SerializeField]
   private Vector3 armPosition;

    public Vector3 _velocity;
    public bool _isGrounded;
    public CharacterController _controller;

//pega controlle
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        arms = AssignCharacterCamera();
    }
    private void Update()
    {
        Movement();
        Gravity();
    }

//transform position na arma
    private Transform AssignCharacterCamera()
    {
        var t = transform;
        arms.SetPositionAndRotation(t.position, t.rotation);
        return arms;
    }

//set de movimente com mesma ideia de antes
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        _controller.Move(move * _moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }

//calculo de gravidade para pula e coisas assim

    private void Gravity()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
