using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour{
    private enum RotationAxes{
        MouseXY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    [SerializeField] float velocidadeVertical = 2.0f;
    [SerializeField] float velocidadeHorizontal = 2.0f;
    [SerializeField] float minVert = -45.0f;
    [SerializeField] float maxVert = 45.0f;
    [SerializeField] private RotationAxes axes = RotationAxes.MouseXY;
    private float _rotacaoEixoX = 0;
    void Start()
    {
        
        var body = GetComponent<Rigidbody>();
        body.freezeRotation = body != null;
    }
    
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*velocidadeHorizontal,0, Space.Self);
        }
        
        else if (axes == RotationAxes.MouseY)
        {
            _rotacaoEixoX -= Input.GetAxis("Mouse Y") * velocidadeVertical;
            _rotacaoEixoX = Mathf.Clamp(_rotacaoEixoX, minVert, maxVert);

            float _rotationAroundY = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(_rotacaoEixoX, _rotationAroundY, 0);
        }
        else
        {
            _rotacaoEixoX -= Input.GetAxis("Mouse Y") * velocidadeVertical;
            _rotacaoEixoX = Mathf.Clamp(_rotacaoEixoX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * velocidadeHorizontal;
            float _rotationAroundY = transform.localEulerAngles.y + delta;
            
            transform.localEulerAngles = new Vector3(_rotacaoEixoX, _rotationAroundY, 0);

        }
    }
}
