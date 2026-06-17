using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 250;
    public float jumpForce = 300; 
    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask tilemapCollisionLayer;
    
    public Rigidbody2D rb; 
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position, tilemapCollisionLayer) != null;
        // != null : **Collider détecté ? Oui -> isGrounded = true ; Non -> isGrounded reste à false**
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.linearVelocity.x);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.1f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < 0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}