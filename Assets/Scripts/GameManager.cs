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
    public GameObject wine;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 20;
    public GameObject titleScreen;
    public TextMeshProUGUI wave;
    public GameObject waveScreen;
    public AudioClip waveSound;
    public GameObject health;
    private float winespawnRate = 10.0f;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public int difficulty;
    private AudioSource audioSource;
    public Ghosts ghost;

    private int currentWave = 1;
    private int targetsToSpawn = 30;
    private int activeEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GetComponent<Ghosts>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemies();
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            for (int i = 0; i < targetsToSpawn; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnRangeZ);
                Instantiate(targets, spawnPos, targets.transform.rotation);
                activeEnemies++;
                yield return new WaitForSeconds(0.5f); // wait half a second between each target
            }

            yield return new WaitWhile(() => activeEnemies > 0); // Wait until all enemies are defeated

            currentWave++;
            if (currentWave == 2)
            {
                audioSource.PlayOneShot(waveSound);
                waveScreen.gameObject.SetActive(true);
                wave.SetText("Wave " + currentWave.ToString());
                StartCoroutine(FadeIn(wave.GetComponent<TextMeshProUGUI>(), 0.5f, 1f));
                targetsToSpawn = 60;
                ghost.UpdateGhostSpeed(currentWave);
            }
            else if (currentWave == 3)
            {
                audioSource.PlayOneShot(waveSound);
                waveScreen.gameObject.SetActive(true);
                wave.SetText("Wave " + currentWave.ToString());
                StartCoroutine(FadeIn(wave.GetComponent<TextMeshProUGUI>(), 0.5f, 1f));
                targetsToSpawn = 70;
                ghost.UpdateGhostSpeed(currentWave);
            }
            else if (currentWave > 3)
            {
                audioSource.PlayOneShot(waveSound);
                waveScreen.gameObject.SetActive(true);
                wave.SetText("Wave " + currentWave.ToString());
                StartCoroutine(FadeIn(wave.GetComponent<TextMeshProUGUI>(), 0.5f, 1f)); 
                spawnRate *= 0.9f;
                targetsToSpawn = Mathf.RoundToInt(targetsToSpawn * 1.2f);
            }

            yield return new WaitForSeconds(0.5f);

            CheckEnemies();
        }
    }

    void CheckEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghost");
        activeEnemies = enemies.Length;
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
        audioSource.PlayOneShot(waveSound);

        waveScreen.gameObject.SetActive(true);
        StartCoroutine(FadeIn(wave.GetComponent<TextMeshProUGUI>(), 0.5f, 1f));
        StartCoroutine(SpawnTarget());
        StartCoroutine(SpawnWine());
    }

    IEnumerator SpawnWine()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(winespawnRate);
            Vector3 spawnPos = new Vector3(Random.Range(-7, 7), 1, Random.Range(3, 13));

            Instantiate(wine, spawnPos, wine.transform.rotation);
        }
    }

    IEnumerator FadeIn(TextMeshProUGUI text, float duration, float targetAlpha)
    {
        Color originalColor = text.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(originalColor.a, targetAlpha, currentTime / duration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        text.color = targetColor;

        yield return new WaitForSeconds(1f);

        StartCoroutine(FadeOut(text, 0.5f));
    }

    IEnumerator FadeOut(TextMeshProUGUI text, float duration)
    {
        Color originalColor = text.color;
        Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        float currentTime = 0f;

        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0f, currentTime / duration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        text.color = targetColor;

        waveScreen.gameObject.SetActive(false);
    }

}