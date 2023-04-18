using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isGameActive { get; private set; }
    private float speed = 5.0f;
    private float runningSpeed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    private float jumpSpeed;
    private float xRange = 8.0f;
    private float zRange = 3f;
    private float zRangeUp = 13f;
    private float gravityModifier = 1f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 6 * forwardInput);
            transform.Translate(Vector3.right * 6 * horizontalInput * Time.deltaTime);
        }

        //Barrier

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRangeUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUp);
        }
    }
        private void OnCollisionEnter(Collision collision)
        {
            // If enemy collides with either goal, destroy it
            if (collision.gameObject.CompareTag("Ghost"))
            {
                Destroy(gameObject);
                isGameActive = false;
        }
    }
}