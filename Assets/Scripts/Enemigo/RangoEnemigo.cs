using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo : MonoBehaviour
{
    public Animator ani;
    public Enemigo1 enemigo;

    public Enemigo1 llamar;




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ani.SetBool("Walk", false);
            ani.SetBool("Run",false);
            ani.SetBool("Attack",true);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
