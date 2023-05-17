using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource playerAudio;
    private Rigidbody enemyRb;
    public ParticleSystem explosionParticle;
    public GameManager gameManager;
    public int speed = 3;

    private Transform player;
    private float originalSpeed;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAudio = GetComponent<AudioSource>();
        originalSpeed = speed;
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;

    }

    public void IncreaseSpeed(float speedMultiplier)
    {
        speed = originalSpeed * speedMultiplier;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "laser(Clone)")
        {
            gameObject.tag = "Dead";
            playerAudio.PlayOneShot(deathSound);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            transform.position += new Vector3(0, -10, 0);
            Destroy(gameObject, deathSound.length);
        }
    }
}
