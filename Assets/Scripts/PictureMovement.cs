using UnityEngine;

public class PictureMovement : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 5f;
    public float speed = 2f;

    private float angle;

    private void Start()
    {
        angle = 0f;
    }

    private void Update()
    {
        // Calculate the new position based on the angle
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float y = centerPoint.position.y + Mathf.Sin(angle) * radius;

        // Set the position of the picture
        transform.position = new Vector3(x, y, transform.position.z);

        // Increment the angle based on the speed and time
        angle += speed * Time.deltaTime;

        // Keep the angle within the range of 0 to 2*pi
        if (angle > 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
}
