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
    public GameObject titleScreen;
    public GameObject health;
    public TextMeshProUGUI waveText;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    private float spawnRate = 1.0f;
    private int score;
    private int difficulty = 1;
    private bool isGameActive;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

            // Check the current score and increase difficulty accordingly
            if (score >= 30 && score < 50)
            {
                difficulty = 2;
                spawnRate = 0.75f;
                waveText.text = "Wave 2";
            }
            else if (score >= 50 && score < 70)
            {
                difficulty = 3;
                spawnRate = 0.5f;
                waveText.text = "Wave 3";
            }
            else if (score >= 70)
            {
                difficulty = 4;
                spawnRate = 0.25f;
                waveText.text = "Wave 4";
            }
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
        audioSource.Stop();
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        health.gameObject.SetActive(true);
        spawnRate = spawnRate / difficulty;
        waveText.text = "Wave 1";

        StartCoroutine(SpawnTarget());
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
