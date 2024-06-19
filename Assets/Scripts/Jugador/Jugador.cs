using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.RegisterPlayer(this);
    }

    private void OnDestroy()
    {
        GameManager.instance.UnregisterPlayer();
    }
}
