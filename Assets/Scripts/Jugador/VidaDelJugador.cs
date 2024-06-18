using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDelJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private BarraDeVida barraDeVida;

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
            Destroy(gameObject);
        }
    }
}
