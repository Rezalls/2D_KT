using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;

    [Header("Jump Settings")]
    [SerializeField] private float _jumpForce;
    private bool _isGrounded;
    private Vector2 _moveInput;
    private bool _jumpPressed;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    //=====================ИНПУТЫ==========================
    //методы вызываются через player input.

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started) 
            _jumpPressed = true;
    }

    //====================ЛОГИКА============================
    private void Update()
    {
        Move();

        if (_jumpPressed)
        {
            Jump();
            _jumpPressed = false;
        }
    }

    //====================ПЕРЕМЕЩЕНИЕ======================

    private void Move()
    {
       // Debug.LogWarning("Движеться, должен");
        _rigidBody2D.linearVelocity = new Vector2(_moveInput.x * _speed, _rigidBody2D.linearVelocity.y);
    }

    //===================ПРЫЖОК============================
    private void Jump()
    {
        //Debug.LogWarning("Прыгает, обязан");
        if(!_isGrounded) return;

        _rigidBody2D.linearVelocity = new Vector2(_rigidBody2D.linearVelocity.x, _jumpForce);
        _isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 1f) ;
        _isGrounded = true;
    }
}
