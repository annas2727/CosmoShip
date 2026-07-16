using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 movement;

    void Update()
    {
        // Get input (WASD or Arrow Keys)
        // GetAxisRaw provides snappy movement (0 or 1)

        HandleMovement();
    }

    void HandleMovement()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return;

        Vector2 direction = Vector2.zero;
    
        if (keyboard.wKey.isPressed) direction += Vector2.up;
        if (keyboard.sKey.isPressed) direction += Vector2.down;
        if (keyboard.aKey.isPressed) direction += Vector2.left;
        if (keyboard.dKey.isPressed) direction += Vector2.right;
        
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
