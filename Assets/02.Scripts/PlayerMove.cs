using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;

    Rigidbody2D _rb;
    bool isGround = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void Move()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            _rb.linearVelocity = new Vector2(-moveSpeed, _rb.linearVelocityY);
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            _rb.linearVelocity = new Vector2(moveSpeed, _rb.linearVelocityY);
        }
    }

    private void Jump()
    {
        if (Keyboard.current.spaceKey.isPressed && isGround)
        {
            isGround = false;
            _rb.AddForceY(5.0f, ForceMode2D.Impulse);
        }
    }
}
