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
    public TextMeshProUGUI wave;
    public GameObject waveScreen;
    public AudioClip waveSound;
    public GameObject health;
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive;
    public int difficulty;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        int wave = 1;
        int targetsToSpawn = 30;

        while (isGameActive)
        {
            for (int i = 0; i < targetsToSpawn; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, spawnRangeZ);

                Instantiate(targets, spawnPos, targets.transform.rotation);
                yield return new WaitForSeconds(0.5f); // wait half a second between each target
            }

            wave++;
            if (wave == 2)
            {
                targetsToSpawn = 60;
            }
            else if (wave == 3)
            {
                targetsToSpawn = 70;
            }
            else if (wave > 3)
            {
                // increase spawn rate and difficulty for subsequent waves
                spawnRate *= 0.9f; // reduce spawn rate by 10%
                targetsToSpawn = Mathf.RoundToInt(targetsToSpawn * 1.2f); // increase number of targets by 20%
            }

            yield return new WaitForSeconds(2f); // wait 2 seconds between waves
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
        audioSource.PlayOneShot(waveSound);

        waveScreen.gameObject.SetActive(true);
        StartCoroutine(FadeIn(wave.GetComponent<TextMeshProUGUI>(), 0.5f, 1f));
        StartCoroutine(SpawnTarget());
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