using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGeneral : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private bool isFacingRight = true;
    [SerializeField] private LayerMask groundLayer; 

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float velocidad)
    {
        rb2D.velocity = new Vector2(velocidad, rb2D.velocity.y);
        if (velocidad != 0) 
        {
            Flip(velocidad);
        }
    }

    public void Jump(float jumpForce)
    {
        if (IsGrounded())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }
    }

    private void Flip(float velocidad)
    {
        if (velocidad > 0 && !isFacingRight)
        {
            isFacingRight = true;
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Abs(localScale.x); 
            transform.localScale = localScale;
        }
        else if (velocidad < 0 && isFacingRight)
        {
            isFacingRight = false;
            Vector3 localScale = transform.localScale;
            localScale.x = -Mathf.Abs(localScale.x); 
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        LayerMask groundLayer = LayerMask.GetMask("Suelo"); 

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
