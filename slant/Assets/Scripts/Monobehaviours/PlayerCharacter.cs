using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float maximumHealth = 100.0f;            // Loose all this and death comes.

    private float currentHealth = 0.0f;             // How much health the player currently has.

    /* Use this for initialization. */
    private void Start()
    {
        currentHealth = maximumHealth;
    }

    /* Update is called once per frame. */
    private void Update()
    {

    }

    /* The player dies if they take damage that meets or surpasses their health pool. */
    public void TakeDamage(float damageAmount)
    {
        // Update health and check for death.
        currentHealth -= damageAmount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    /* Behaviour thata happens on death. */
    private void Die()
    {
        // Deathy stuff...
    }
}