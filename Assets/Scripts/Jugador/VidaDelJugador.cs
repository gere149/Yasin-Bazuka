using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaDelJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;

    public event EventHandler MuerteJugador;

    private void Start()
    {
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        barraDeVida.CambiarVidaActual(vida);

        if(vida <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
