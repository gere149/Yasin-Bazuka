using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UssopMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2 (horizontal, rigidbody2D.velocity.y);
    }

    void moveCharacter(float horizontal)
    {
    rigidbody2D.AddForce(Vector2.right * horizontal * moveSpeed);

    if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)){
        Flip();
    }
    if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed){
        rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
    }
    animator.SetFloat("horizontal", Mathf.Abs(rigidbody2D.velocity.x));
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
}
