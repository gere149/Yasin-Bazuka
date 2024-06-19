using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2D;
    private Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Componentes")]
    public SpriteRenderer healthBar;
    public Transform healthBarTransform;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        BuscarJugador();        
    }

    private void Update()
    {
        if(jugador != null)
        {
            float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
            animator.SetFloat("distanciaJugador", distanciaJugador);
            MirarJugador();
        }
        else
        {
            BuscarJugador();
        }
    }

    private void BuscarJugador()
    {
        GameObject jugadorObj = GameObject.FindGameObjectWithTag("Player");
        if (jugadorObj != null)
        {
            jugador = jugadorObj.transform;
        }
    }

    public void Morir()
    {
        animator.SetTrigger("Muerte 0");
        Destroy(gameObject, 1f);
    }

    public void MirarJugador()
    {
        if (jugador != null)
        {
            if ((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
            {
                mirandoDerecha = !mirandoDerecha;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
        }
    }

    public Transform GetJugador()
    {
        return jugador;
    }




    /*private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;

    [Header("Vida")]
    [SerializeField] private float vida;
    private float vidaMax = 100;
    public SpriteRenderer healthBar;
    public Transform healthBarTransform;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float dañoAtaque;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);

        ActualizarBarraDeVida(vida);
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        if(vida <= 0)
        {
            animator.SetTrigger("Muerte 0");
            Muerte(1);
        }
    }

    private void Muerte(int time)
    {
        Destroy(gameObject, time);
    }

    public void MirarJugador()
    {
        if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    //Intentar usar a partir de aqui el codigo y crear un Ataque general que sirva para CombateCac de player y Enemigo de enemy.
    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D colision in objetos)
        {
            if(colision.CompareTag("Player"))
            {
                colision.GetComponent<VidaDelJugador>().TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

    private void ActualizarBarraDeVida(float porcentajeVida)
    {
        porcentajeVida = (float)vida / vidaMax;
        healthBarTransform.transform.localScale = new Vector3(porcentajeVida * 0.5f, 0.06810274f, 1f);
        healthBar.color = Color.Lerp(Color.red, Color.green, porcentajeVida);
    }*/
}
