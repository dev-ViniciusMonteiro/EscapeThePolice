using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//trava a camera
public class CameraLook : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 100;

    [SerializeField]
    private Transform _playerBody;

    private float _xRotation = 0;

    private void Awake()
    {
        //https://docs.unity3d.com/ScriptReference/Cursor-lockState.html
        //Cursor.lockState = CursorLockMode.None 
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        LookAround();
    }

    private void LookAround()
    {
        //jogo entre mause e rotacao
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        //https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html
        _xRotation = Mathf.Clamp(_xRotation, -70, 55);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
