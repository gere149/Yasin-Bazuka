using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{   
    private Animator animator;
    public Rigidbody2D rb2D;
    private bool mirandoDerecha = true;
    private MovimientoGeneral movimientoGeneral;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        movimientoGeneral = GetComponent<MovimientoGeneral>();
    }

    void Update()
    {
        Vector3 targetPosition = GameManager.instance.GetTargetLocation();
        float distanciaJugador = Vector2.Distance(transform.position, targetPosition);
        animator.SetFloat("distanciaJugador", distanciaJugador);
        MirarJugador();
    }

    public void Morir()
    {
        animator.SetTrigger("Muerte 0");
        Destroy(gameObject, 1f);
    }

    void MirarJugador()
    {
        Vector3 targetPosition = GameManager.instance.GetTargetLocation();
        if ((targetPosition.x > transform.position.x && !mirandoDerecha) || (targetPosition.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
}
