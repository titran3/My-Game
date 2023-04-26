using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement1 : MonoBehaviour
{
    public float amplitude = 1f; // How far the image will move up and down
    public float speed = 1f; // How fast the image will move

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new y position for the image based on time
        float newY = Mathf.Sin(Time.time * speed) * amplitude;

        // Set the image's new position
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}