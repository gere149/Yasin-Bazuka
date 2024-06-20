using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IanaMov : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private Animator animator;
    private MovimientoGeneral movementController;

    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<MovimientoGeneral>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetBool("running", horizontal != 0.0f);
        animator.SetFloat("jumpVelocidad", movementController.rb2D.velocity.y); 

        if (Input.GetButtonDown("Jump"))
        {
            movementController.Jump(jumpingPower);
        }

        movementController.Move(horizontal * speed);
    }
}

