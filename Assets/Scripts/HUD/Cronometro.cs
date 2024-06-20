using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Cronometro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cronometroTexto;
    float tiempoTranscurrido;
    private bool contando = true;

    void Update()
    {
        if(contando)
        {
            tiempoTranscurrido += Time.deltaTime;
            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
            cronometroTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        
    }

    public void DetenerCronometro()
    {
        contando = false;
    }
}
