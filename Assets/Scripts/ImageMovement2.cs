using UnityEngine;
using UnityEngine.UI;

public class ImageMovement2 : MonoBehaviour
{
    public RectTransform centerPoint;
    public float radius = 100f;
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

        // Set the anchored position of the image
        RectTransform imageTransform = GetComponent<RectTransform>();
        imageTransform.anchoredPosition = new Vector2(x, y);

        // Increment the angle based on the speed and time
        angle += speed * Time.deltaTime;

        // Keep the angle within the range of 0 to 2*pi
        if (angle > 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
}
