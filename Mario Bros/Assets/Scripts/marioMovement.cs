using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float jumpForce = 10f; 
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if Mario is grounded using Rigidbody2D's IsTouchingLayers method
        isGrounded = rb.IsTouchingLayers(groundLayer);

        // Check for jumping input in the Update method
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip Mario sprite if necessary
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
