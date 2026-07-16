using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float mouseDistanceFromPlayer = 0f;

    void Update()
    {
        // 1. Get mouse position in world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 2. Calculate direction from sprite to mouse
        // Note: For 2D, we ignore the Z axis (set it to sprite's Z)
        mouseDistanceFromPlayer = Mathf.Sqrt(Mathf.Pow(mouseWorldPosition.x - transform.position.x,2) + Mathf.Pow(mouseWorldPosition.y - transform.position.y,2));
        Vector2 direction = new Vector2(
            mouseWorldPosition.x - transform.position.x,
            mouseWorldPosition.y - transform.position.y
        );

        // 3. Calculate angle and apply rotation
        // Mathf.Atan2 returns the angle in radians; Rad2Deg converts it
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Use -90 offset if your sprite faces "Up" by default
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}