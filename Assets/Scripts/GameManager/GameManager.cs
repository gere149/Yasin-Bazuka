using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Jugador registeredPlayer;
    private Vector3 lastKnownPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPlayer(Jugador player)
    {
        registeredPlayer = player;
    }

    public void UnregisterPlayer(Jugador player)
    {
        if (registeredPlayer == player)
        {
            registeredPlayer = null;
        }
    }

    public Vector3 GetTargetLocation()
    {
        if (registeredPlayer != null)
        {
            lastKnownPosition = registeredPlayer.transform.position;
        }
        return lastKnownPosition;
    }
}
