using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthScript health = other.GetComponent<HealthScript>();
            if (health != null)
            {
                health.IncreaseHealth();
            }
            Destroy(gameObject);
        }
    }
}

