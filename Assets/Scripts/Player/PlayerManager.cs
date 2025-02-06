using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed = 3f;
    public Rigidbody2D rb;
    private float horizontalMovement;

    [Header("Player Jump")]
    [SerializeField] private float jumpForce;

    [Header("Player Collision")]
    [SerializeField] private float groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    [Header("Player Animation")]
    private Animator anim;
    private bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundChecked(); // check if the player is on the ground 
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);

        // jump for the player
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Flip the player if necessary
        if (horizontalMovement > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalMovement < 0 && isFacingRight)
        {
            Flip();
        }

        Animation(); // call the animation function
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void GroundChecked()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheck, groundLayer);
    }

    private void Animation()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    // Flip the player
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}