using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval = 10.0f;
    bool cooldown = true;
    bool bursting = false;
    public AudioClip gunSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting Gun
        if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Space)) && cooldown)
        {
            StartCoroutine(Cooldown());

            // Only call Burst() once if any input is detected
            if (!bursting)
            {
                StartCoroutine(Burst());
            }
        }
    }


    void Shooting()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        playerAudio.PlayOneShot(gunSound);
    }

    IEnumerator Burst()
    {
        bursting = true;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Shooting with left mouse button
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        else if (Input.GetKey(KeyCode.Mouse1))
        {
            // Shooting with right mouse button
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            // Shooting with spacebar
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        playerAudio.PlayOneShot(gunSound);
        yield return new WaitForSeconds(0.15F);
        bursting = false;
    }


    IEnumerator Cooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(0.2F);
        cooldown = true;
    }
}
