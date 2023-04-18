using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval= 10.0f;
    bool cooldown = true;
    public AudioClip gunSound;
    private  AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting Gun
        if (Input.GetKey(KeyCode.Mouse0) && cooldown)
        {
            StartCoroutine(Cooldown());
            StartCoroutine(Burst());
        }
    }
    void Shooting()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        playerAudio.PlayOneShot(gunSound);
    }
    IEnumerator Burst()
    {
        Shooting();
        yield return new WaitForSeconds(0.15F);
    }

    IEnumerator Cooldown()
    {
        cooldown = false;
        yield return new WaitForSeconds(0.2F);
        cooldown = true;
    }
}
