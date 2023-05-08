using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speedBoost = 5f; // The amount of speed to add to the player's current speed.

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object that collided with the powerup is the player.
        {
            PlayerController player = other.GetComponent<PlayerController>(); // Get the player's PlayerController component.
            player.speed += speedBoost; // Increase the player's speed.
            Destroy(gameObject); // Destroy the powerup object.
        }
    }
}
