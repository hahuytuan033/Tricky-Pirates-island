using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private bool _active = true;
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

    [Header("Player Death")]
    private Collider2D _collider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // die
        if (!_active)
        {
            return;
        }

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

        // thay đổi ở đây
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

    // Move the player
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

    // Player Death

    private void MiniJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce / 2);
    }

    public void Die()
    {
        _active = false;
        _collider.enabled = false;
        MiniJump();
    }
}