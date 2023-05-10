using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval = 10.0f;
    public int maxBullets = 30; // maximum number of bullets
    public float reloadTime = 2.0f; // time it takes to reload
    int bullets; // current number of bullets
    bool reloading = false; // true if reloading
    bool cooldown = true;
    bool bursting = false;
    public AudioClip gunSound;
    private GameManager gameManager;
    public AudioClip reloadSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        bullets = maxBullets;
    }


    // Update is called once per frame
    void Update()
    {
        // Shooting Gun
        if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Space)) && cooldown && !reloading && bullets > 0)
        {
            StartCoroutine(Cooldown());

            // Only call Burst() once if any input is detected
            if (!bursting)
            {
                StartCoroutine(Burst());
            }
        }

        // Reload Gun
        if (Input.GetKeyDown(KeyCode.R) && !reloading && bullets < maxBullets)
        {
            StartCoroutine(Reload());
        }
    }

    void Shooting()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        playerAudio.PlayOneShot(gunSound);
        bullets--;
    }

    IEnumerator Burst()
    {
        bursting = true;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Shooting with left mouse button
            Shooting();
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            // Shooting with right mouse button
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(gunSound);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            // Shooting with spacebar
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(gunSound);
        }

        yield return new WaitForSeconds(0.15F);
        bursting = false;
    }

    IEnumerator Cooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(0.2F);
        cooldown = true;
    }

    IEnumerator Reload()
    {
        reloading = true;

        // Play reload sound
        playerAudio.PlayOneShot(reloadSound);

        // Wait for reload time
        yield return new WaitForSeconds(reloadTime);

        // Refill bullets and stop reloading
        bullets = maxBullets;
        reloading = false;
    }

    void OnGUI()
    {
        // Display current bullets in bottom right corner of screen
        GUI.Label(new Rect(Screen.width - 110, Screen.height - 30, 100, 20), "Bullets: " + bullets);
    }

}