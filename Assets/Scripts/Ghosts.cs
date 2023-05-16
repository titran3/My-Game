using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosts : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource playerAudio;
    private Rigidbody enemyRb;
    public ParticleSystem explosionParticle;
    public float speed = 0.5f;
    private float knockback = 100.0f;
    // Start is called before the first frame update
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "laser(Clone)")
        {
            gameObject.tag = "Dead";
            playerAudio.PlayOneShot(deathSound);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            transform.position += new Vector3(0, -10, 0);
            Destroy(gameObject, deathSound.length);
        }

    }
    public void UpdateGhostSpeed(float speedMultiplier)
    {
        speed *= speedMultiplier;
    }
}
