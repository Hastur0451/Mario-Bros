using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of Mario's movement
    public float jumpForce = 5f; // Force of Mario's jump
    //public Transform groundCheck; // Transform to check if Mario is grounded
    //public LayerMask groundLayer; // LayerMask to define what is considered ground

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Check if Mario is grounded
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip Mario sprite
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    //flip Mario's sprite horizontally
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}