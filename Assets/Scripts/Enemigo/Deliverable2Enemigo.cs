using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

/*public class EnemigoDeliverable2 : MonoBehaviour
{
    public Animator ani;
    public float speed_run;
    public GameObject target;
    private bool atacando;
    public float rango_vision;
    public float rango_ataque;
    public float cooldownDaño;
    private float momentoDaño;
    public GameObject rango;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Comportamientos();
    }

    public void Comportamientos()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) < rango_vision && !atacando)
        {

            if (transform.position.x < target.transform.position.x)
            {
                ani.SetBool("Run", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                ani.SetBool("Attack", false);
            }
            else
            {
                ani.SetBool("Run", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                ani.SetBool("Attack", false);
            }
        }
        else
        {
            if (!atacando)
            {
                if (transform.position.x < target.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                ani.SetBool("Run",false);
            }
        } 
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && atacando == true)
        {
            if(Time.time > momentoDaño + cooldownDaño)
            {
                collision.GetComponent<IanaVida>().IanaPierdeVida();
                momentoDaño = Time.time;
                atacando = false;
                ani.SetBool("Attack", false);
                print("Damage");
            }
        }
        else if (collision.CompareTag("Player") && atacando == false)
        {
            ani.SetBool("Run",false);
            ani.SetBool("Attack",true);
            atacando = true;
        }
        else
        {
            ani.SetBool("Run",true);
            ani.SetBool("Attack",false);
            atacando = false;
        }
        
    }
    

    private void Final_Ani()
    {
        ani.SetBool("Attack",false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void LlamadaAni()
    {
        Final_Ani();
    }


    
}*/
