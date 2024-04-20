using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UssopMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    public float moveSpeed;
    public Vector2 direction;
    private bool facingRight = true;
    public float maxSpeed;
    public float linearDrag;
    public Animator animator;
    public Transform position;

    public float Speed;
    public float JumpForce;
    private bool AlTerra;

    private Animator Animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Vector3 Movementnew = new Vector3(horizontal,0,0);

        transform.position += Movementnew * moveSpeed * Time.deltaTime;

        Animator.SetBool("running", horizontal != 0.0f);


        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

    }

    private void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * JumpForce);
    }


    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
}
