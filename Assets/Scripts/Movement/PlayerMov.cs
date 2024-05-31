using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : GeneralMovement
{
    private float horizontal;
    private float speed = 8f;
    [SerializeField] float jumpingPower;
    public LayerMask groundLayer;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetBool("running", horizontal != 0.0f);
        animator.SetFloat("jumpVelocidad", rb.velocity.y);
        HandleJump();
        Flip(horizontal);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.2f, groundLayer);
        return raycastHit.collider != null;
    }
}
