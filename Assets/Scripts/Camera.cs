using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    private float smoothTime = 0.25f;
    private Vector3 offset = new Vector3(0, 10, 0);
    private Vector3 velocity = Vector3.zero;
    public float zRange = 1f;
    public float xRange = 1f;

    [SerializeField] private Transform target;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetposition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothTime);
    
    }
}