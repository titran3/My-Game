using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject player;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("you got hit");
            currentHealth--;
            UpdateHeartsUI();
            if (currentHealth <= 0)
            {
                Destroy(player);
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
                hearts[i].enabled = true; // show the heart
            }
            else
            {
                hearts[i].sprite = emptyHeart;
                hearts[i].enabled = false; // hide the heart
            }
        }
    }
}
