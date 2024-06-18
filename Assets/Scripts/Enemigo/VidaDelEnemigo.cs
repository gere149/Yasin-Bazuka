using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDelEnemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private float vidaMax = 100;
    public SpriteRenderer healthBar;
    public Transform healthBarTransform;

    private void Start()
    {
        vida = vidaMax;
        ActualizarBarraDeVida();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            GetComponent<Enemigo>().Morir();
        }

        ActualizarBarraDeVida();
    }

    private void ActualizarBarraDeVida()
    {
        float porcentajeVida = vida / vidaMax;
        healthBarTransform.localScale = new Vector3(porcentajeVida * 0.5f, 0.06810274f, 1f);
        healthBar.color = Color.Lerp(Color.red, Color.green, porcentajeVida);
    }
}
