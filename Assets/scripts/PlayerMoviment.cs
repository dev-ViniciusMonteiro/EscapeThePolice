using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [Header("Movement")]
    public float SpeedMove = 6.0f;

    public float multipierMovimente = 10f;
    float DragForce = 6.0f;

    float movimentHorizontal;
    float movimentVertical;

    Vector3 DirectionMove;

    Rigidbody rb;

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        ButtonInput();
        DragControll();
    }

    void ButtonInput()
    {
        movimentHorizontal = Input.GetAxisRaw("Horizontal");
        movimentVertical = Input.GetAxisRaw("Vertical");

        DirectionMove = transform.forward * movimentVertical + transform.right * movimentHorizontal;
    }

    void DragControll()
    {
        rb.drag = DragForce;
    }

    private void FixedUpdate()
    {
        rb.AddForce(DirectionMove.normalized * SpeedMove * multipierMovimente, ForceMode.Acceleration);
    }

}
