using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask enSuelo;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        rb.velocity = new Vector2(velocidadMovimiento * transform.right.x, rb.velocity.y);
        RaycastHit2D informacionSuelo = Physics2D.Raycast(transform.position, transform.right, distancia, enSuelo);

        if(informacionSuelo)
        {
             Flip();

        }

        
    }


    private void Flip()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

    }


    private void OnDrawGizmosSelect()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine (transform.position, transform.position + transform.right * distancia); 
    }

}
