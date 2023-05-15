using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject player;
    public AudioClip deathSound;
    public AudioSource audioSource;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private GameManager gameManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    public void IncreaseHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            UpdateHeartsUI();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("you got hit");
            currentHealth--;
            audioSource.PlayOneShot(deathSound);
            UpdateHeartsUI();
            if (currentHealth <= 0)
            {
                gameManager.GameOver();
                Destroy(gameObject);
            }
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                hearts[i].enabled = false;
            }
        }
    }
}
