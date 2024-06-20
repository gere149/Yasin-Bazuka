using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaDelJugador : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2D;
    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;
    public event EventHandler MuerteJugador;
    public Cronometro cronometro;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        barraDeVida.CambiarVidaActual(vida);

        if(vida <= 0)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("Muerte");   
            cronometro.DetenerCronometro();
        }
    }

    public void MuerteJugadorEvento()
    {
        MuerteJugador?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
}
