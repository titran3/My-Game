using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects; // Array of objects to spawn
    public float spawnRate = 1.0f; // Rate at which to spawn objects
    public float spawnRadius = 10.0f; // Maximum distance from spawner to spawn objects

    private float spawnTimer = 2.0f; // Timer for spawning objects

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // If it's time to spawn a new object...
        if (spawnTimer >= spawnRate)
        {
            // Reset the spawn timer
            spawnTimer = 2.0f;

            // Choose a random object to spawn
            int randomIndex = Random.Range(0, spawnObjects.Length);
            GameObject objectToSpawn = spawnObjects[randomIndex];

            // Choose a random position to spawn the object
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Spawn the object
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
