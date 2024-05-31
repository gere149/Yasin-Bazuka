using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMov : GeneralMovement
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float detectionDistance;
    private Transform playerTransform;
    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        float distanciaJugador = Vector2.Distance(transform.position, playerTransform.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) <= detectionDistance)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * movementSpeed, rb.velocity.y);
            Flip(direction.x);
        }
    }




    
}
