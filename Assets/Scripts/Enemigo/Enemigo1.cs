using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direcction;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;

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
                //ani.SetBool("Walk", false);
                ani.SetBool("Run", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                ani.SetBool("Attack", false);
            }
            else
            {
                //ani.SetBool("Walk", false);
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
                //ani.SetBool("Walk", false);
                ani.SetBool("Run",false);
            }
        } 
       
    }
    private void Final_Ani()
    {
        ani.SetBool("Attack",false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void LlamadaAni()
    {
        Final_Ani();
    }


    
}
