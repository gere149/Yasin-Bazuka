using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IanaCombate : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach(Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("VidaEnemigo"))
            {
                colisionador.transform.GetComponent<ControladorEnemigo>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
