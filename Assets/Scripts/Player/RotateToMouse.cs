using UnityEngine;
using UnityEngine.InputSystem;

public class RotateToMouse : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mouseScreen = Mouse.current.position.ReadValue();

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = transform.position.z;

        Vector2 direction = mouseWorld - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
   
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}