using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 5.0f;
    private float runningSpeed= 10f;
    private float horizontalInput;
    private float forwardInput;
    private float runningCooldown = 3.5f;
    private float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp = Time.time + runningCooldown;
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (timeStamp <= Time.time)
        {
            Running();
        }

        }
    }
    void Running(){
        if (Input.GetKey(KeyCode.LeftShift)){
             transform.Translate(Vector3.forward * Time.deltaTime * runningSpeed * forwardInput);
             transform.Translate(Vector3.right * runningSpeed * horizontalInput * Time.deltaTime);
    }
}
