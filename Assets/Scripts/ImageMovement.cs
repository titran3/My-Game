using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMovement : MonoBehaviour
{
    public float amplitude = 1f; // How far the image will move from side to side
    public float speed = 1f; // How fast the image will move

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new x position for the image based on time
        float newX = Mathf.Sin(Time.time * speed) * amplitude;

        // Set the image's new position
        transform.position = new Vector3(startPos.x + newX, startPos.y, startPos.z);
    }
}
