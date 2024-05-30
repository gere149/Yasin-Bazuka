using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] private float vida;
    private Animator animator;
    public Rigidbody2D rb;
    public Transform jugador;
    private bool mirandoDerecha = true;
    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody2D>();
        controladorAtaque = GameObject.FindGameObjectWithTag("ControladorAtaque").GetComponent<Transform>();
    } 

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
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
        animator.SetTrigger("Muerte 0");
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D colision in objetos)
        {
            if(colision.CompareTag("Player"))
            {
                colision.GetComponent<CombateJugador>().TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
