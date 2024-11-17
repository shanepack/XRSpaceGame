using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    // The maximum health of the object
    public int maxHealth = 10;
    // The current health of the object
    private int currentHealth;

    // Reference to the explosion particle effect prefab
    public GameObject explosionEffect;
    // Reference to the explosion sound clip
    public AudioClip explosionSound;

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
    }

    // Method to apply damage to the object
    public void TakeDamage(int damageAmount)
    {
        // Reduce current health by the damage amount
        currentHealth -= damageAmount;

        // Check if the object's health has reached zero or below
        if (currentHealth <= 0)
        {
            // Play the explosion effect
            if (explosionEffect != null)
            {
                // Instantiate the explosion effect at the object's position and rotation
                GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);

                // Optionally, destroy the explosion effect after its duration
                // Assuming the particle system has a duration of 2 seconds
                Destroy(explosion, 2f);
            }

            // Play the explosion sound
            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            // Destroy the game object
            Destroy(gameObject);
        }
    }
}
