using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{

    [SerializeField] private float vida;
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if(vida <= 0)
        {
            Muerte();
        }
    }
    
    private void Muerte()
    {
        if(vida <= 0)
        {
            ani.SetBool("Muerte", true);
            
        }
        else
        {
            ani.SetBool("Muerte", false);
        }
    }

}
