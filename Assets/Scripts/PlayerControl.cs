using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5.0f;
    private float runningSpeed= 6.0f;
    private float horizontalInput;
    private float forwardInput;
    private float runningCooldown = 3.5f;
    private float timeStamp;
    private float jumpSpeed= 2f;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp = Time.time + runningCooldown;
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift)){
         transform.Translate(Vector3.forward * Time.deltaTime * runningSpeed * forwardInput);
         transform.Translate(Vector3.right * runningSpeed * horizontalInput * Time.deltaTime);
         }
         if (Input.GetKey(KeyCode.Space)){
        playerRb.AddForce(Vector3.up * Time.deltaTime * jumpSpeed);
         }
        }

    }