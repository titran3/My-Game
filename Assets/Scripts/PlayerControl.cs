using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public bool isGameActive { get; private set; }
    public float speed = 5.0f;
    private float runningSpeed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    private float jumpSpeed;
    private float xRange = 8.0f;
    private float zRange = 3f;
    private float zRangeUp = 13f;
    private float gravityModifier = 1f;
    private Rigidbody playerRb;
    private HealthBarHUDTester healthControl;
    public Transform cameraTransform;
    private float cameraDistance = 10.0f;
    private float cameraRotateSpeed = 5.0f;
    public bool hasPowerup = false;
    public float speedBoost = 20f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        healthControl = FindObjectOfType<HealthBarHUDTester>();
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
        transform.Translate(Vector3.down * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 6 * forwardInput);
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

        // Camera rotation
        float mouseX = Input.GetAxis("Mouse X") * cameraRotateSpeed;

        transform.rotation *= Quaternion.Euler(0f, 0f, mouseX);

        Vector3 cameraTargetRotation = cameraTransform.rotation.eulerAngles;
        cameraTargetRotation.x = Mathf.Clamp(cameraTargetRotation.x, -90f, -90f);

        cameraTransform.rotation = Quaternion.Euler(cameraTargetRotation);
        cameraTransform.position = transform.position - cameraTransform.forward * cameraDistance;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup")) // Check if the object that collided with the powerup is the player.
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
}

