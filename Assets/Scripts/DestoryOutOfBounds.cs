using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    private float zRangeUp = 20f;
    public GameObject laser;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zRangeUp)
        {
            Destroy(gameObject);
        }
    }
}
