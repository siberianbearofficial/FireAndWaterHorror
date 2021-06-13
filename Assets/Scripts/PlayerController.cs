using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 hor_vector;
    public int const_jump_count = 1;
    private int jump_count = 1;
    private float ver_speed;
    private float hor_speed;
    private bool isGrounded = true;
    private bool facing_right = true;
    public float mov_speed;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatType;
    public float jumpForce = 5;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if (isGrounded) 
        {
            jump_count = const_jump_count;
        } 
        hor_speed = Input.GetAxis("Horizontal");
        if (Input.GetKeyUp(KeyCode.Space) && jump_count > 0)
        {
            _rigidbody.velocity = Vector2.up * jumpForce;
            jump_count--;
        }
    }

    private void FixedUpdate() 
    {
        isGrounded = (Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatType) && _rigidbody.velocity.y < 0);
        Move();
        if (facing_right == false && hor_speed > 0)
        {
            Flip();
        }
        else if (facing_right == true && hor_speed < 0)
        {
            Flip();
        }
    }

    private void Move() 
    {
        hor_vector.Set(hor_speed * mov_speed, _rigidbody.velocity.y);
        _rigidbody.velocity = hor_vector;
    }

    private void Flip() 
    {
        facing_right = !facing_right;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
