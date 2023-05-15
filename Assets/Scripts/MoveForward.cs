using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 80.0f;
    // Update is called once per frame
    void Update()
    {
        //Moves forward
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "pitch(Clone)")
        {
            Destroy(gameObject);
        }

    }
}
