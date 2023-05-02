using UnityEngine;
using System.Collections;

public class SpawnWineBottle : MonoBehaviour {
    public GameObject wineBottlePrefab; // The prefab of the wine bottle to be spawned.
    public Transform spawnPoint; // The position where the wine bottle should be spawned.
    public float spawnTime = 20.0f; // The time between each wine bottle spawn.

    void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn () {
        Instantiate(wineBottlePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}