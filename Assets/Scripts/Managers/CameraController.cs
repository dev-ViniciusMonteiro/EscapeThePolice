using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _firstViewCamera;
    [SerializeField] private Camera _thirdViewCamera;
    public Camera currentCamera;


    private void Start()
    {
        _firstViewCamera = Camera.main;
        _thirdViewCamera = GameObject.FindGameObjectWithTag("ThirdViewCamera").GetComponent<Camera>() as Camera;
        currentCamera = _firstViewCamera;
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            _firstViewCamera.enabled = true;
            _thirdViewCamera.enabled = false;
            currentCamera = _firstViewCamera;
        }
        else if (Input.GetKeyDown("2"))
        {
            _firstViewCamera.enabled = false;
            _thirdViewCamera.enabled = true;
            currentCamera = _thirdViewCamera;
        }
    }
}