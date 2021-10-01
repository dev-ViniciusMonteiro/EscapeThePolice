using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _firstViewCamera;
    [SerializeField] private Camera _thirdViewCamera;
    private int _person = 0;
    
    public Camera currentCamera;
    private void Start(){
        _firstViewCamera = Camera.main;
        _thirdViewCamera = GameObject.FindGameObjectWithTag("ThirdViewCamera").GetComponent<Camera>() as Camera;
        currentCamera = _firstViewCamera;
    }

    void Update(){
        if (Input.GetKeyDown("h")&&_person==0){
            _firstViewCamera.enabled = true;
            _thirdViewCamera.enabled = false;
            currentCamera = _firstViewCamera;
            _person=1;
        }

        else if (Input.GetKeyDown("h")&&_person==1){
            _firstViewCamera.enabled = false;
            _thirdViewCamera.enabled = true;
            currentCamera = _thirdViewCamera;
            _person=0;
        }
    }
}