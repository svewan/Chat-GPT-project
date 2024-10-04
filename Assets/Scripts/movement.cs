using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = true;

    private Rigidbody2D rb;
    private Vector2 currentGravity = Vector2.down; // Default gravity direction
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main; // Get reference to the main camera
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Get the current gravity direction and adjust movement accordingly
        Vector2 moveDirection = Vector2.Perpendicular(currentGravity).normalized; // Movement is perpendicular to gravity
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Apply velocity for movement while maintaining gravity-based velocity
        Vector2 horizontalMovement = moveDirection * moveHorizontal * moveSpeed;
        Vector2 newVelocity = Vector2.Dot(rb.velocity, currentGravity) * currentGravity + horizontalMovement; // Maintain gravity velocity
        rb.velocity = newVelocity;
    }

    void Jump()
    {
        // Jump in the opposite direction of gravity if grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.Dot(rb.velocity, Vector2.Perpendicular(currentGravity)) * Vector2.Perpendicular(currentGravity); // Cancel out horizontal movement while jumping
            rb.AddForce(-currentGravity * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Crate"))
        {
            isGrounded = true;
        }

        // Check if the cube is touching a wall and change gravity
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Get the wall normal (the direction the wall is facing)
            Vector2 wallNormal = collision.contacts[0].normal;

            // Change gravity to pull toward the wall
            currentGravity = -wallNormal;

            // Set the global gravity to match the new direction
            Physics2D.gravity = currentGravity * 9.81f;

            // Rotate the camera to match the new gravity
            RotateCameraToGravity();

            isGrounded = true; // Treat the wall as ground
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
        }
    }

    void RotateCameraToGravity()
    {
        // Determine the angle based on the current gravity
        float angle = Vector2.SignedAngle(Vector2.down, currentGravity);

        // Rotate the camera smoothly to match the gravity direction
        mainCamera.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
