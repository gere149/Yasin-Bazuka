using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moro : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public int direcction;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Iana");
    }

    public void Comportamientos()
    {
        ani.SetBool("Run", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }

        switch (rutina)
        {
            case 0:
                ani.SetBool("Walk", false);
                break;

            case 1:
                direcction = Random.Range(0,2);
                rutina++;
                break;

            case 2:

                switch (direcction)
                {
                    case 0:

                        transform.rotation = Quaternion.Euler(0,0,0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;

                    case 1:

                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                }
                ani.SetBool("Walk", true);
                break;


                    
        }
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();
    }
}
