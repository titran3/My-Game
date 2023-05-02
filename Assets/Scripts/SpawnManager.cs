using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    public GameObject[] ghostPrefabs;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    public GameObject player;
    private PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();

            SpawnRandomAnimal();

        // Update is called once per frame
        void Update()
        {
        }

        void SpawnRandomAnimal()
        {
            // Randomly Generate Index and Position
            int ghostIndex = Random.Range(0, ghostPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnRangeZ);

            Instantiate(ghostPrefabs[ghostIndex], spawnPos, ghostPrefabs[ghostIndex].transform.rotation);
        }
    }
}
