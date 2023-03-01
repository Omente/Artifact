using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int MaxHealth { get { return maxHealth; } }

    private int health;
    public int Health { get { return health; } }
    private int bleed = 2;
    private float bleedTimer;
    private AudioSource audioSource;
    private PlayerBackpack playerBackpack;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        bleedTimer = Time.time + 1f;
        playerBackpack = FindObjectOfType<PlayerBackpack>();
    }

    private void Update()
    {
        if(Time.time > bleedTimer)
        {
            health -= bleed;
            bleedTimer = Time.time + 1f;
            CheckHealth();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;

            //Show game over UI
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(playerBackpack.CurrentNumberOfFruits != 0) audioSource.Play();
            
            health += playerBackpack.TakeFruits();

            if (health > maxHealth) health = maxHealth;

        }
    }
}
