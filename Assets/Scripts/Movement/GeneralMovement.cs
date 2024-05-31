using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour
{
    protected bool isFacingRight = true;
    public float moveSpeed = 5f;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected BoxCollider2D boxCollider;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void Move(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
    }

    protected void Flip(float horizontal)
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
