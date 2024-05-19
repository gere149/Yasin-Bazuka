using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IanaVida : MonoBehaviour
{
    public float vida;
    public float maxVida;
    public float dañoQueRecibo;

    private Animator ani;

    void Start()
    {
        vida = maxVida;
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(vida <= 0)
        {
            Muerte();
        }
        else
        {
            ani.SetBool("Muerte", false);
        }
    }

    private void Muerte()
    {
        ani.SetBool("Muerte", true);
    }

    public void IanaPierdeVida()
    {
        vida-= dañoQueRecibo;
    }
}
