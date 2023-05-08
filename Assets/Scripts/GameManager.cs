using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject targets;

    public Button restartButton;
    public GameObject gameOver;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    public GameObject titleScreen;
    public GameObject health;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnRangeZ);

            Instantiate(targets, spawnPos, targets.transform.rotation);
        }
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        health.gameObject.SetActive(true);
        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnTarget());
    }
}
