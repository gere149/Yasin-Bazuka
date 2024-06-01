using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    /*public event Action HealthChanged;
    [SerializeField]
    private int minHealth = 0;
    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MinHealth => minHealth;
    public int MaxHealth => maxHealth;*/
    [SerializeField] private float vida;
    private Animator animator;
    private Transform playerTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    /*public void Decrement(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);
    }*/

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
        animator.SetTrigger("Muerte");
        Destroy(gameObject);
    }

}
