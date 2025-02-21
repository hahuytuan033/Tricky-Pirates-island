using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    [SerializeField] public float groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    [Header("Player Animation")]
    private Animator anim;
    private bool isFacingRight = true;

    [Header("Player Death")]
    private Collider2D _collider;

    [Header("Player Respawn")]
    private Vector2 respawnPoint;


    AudioManager audioManager;


    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        _collider = GetComponent<Collider2D>();
        SetRespawnPoint(transform.position);
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

    // Jump function
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        else if (context.canceled && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    // Check if the player is on the ground
    private void GroundChecked()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheck, groundLayer);
    }

    // Animation function
    private void Animation()
    {
        // Player animation
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

    public void SetRespawnPoint(Vector2 position)
    {
        respawnPoint = position;
    }

    public void Die()
    {
        _active = false;
        _collider.enabled = false;
        MiniJump();
        StartCoroutine(Respawn());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            audioManager.PlayGameOverSound();
            Die();
        }

        if (other.gameObject.CompareTag("Bottle"))
        {
            audioManager.PlaySFX(audioManager.powerUpSound);
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            groundCheck = 3f;
        }

        if (transform.localScale == new Vector3(2.5f, 2.5f, 2.5f) && other.gameObject.CompareTag("Big Ground"))
        {
            Rigidbody2D bigGroundRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (bigGroundRb != null)
            {
                bigGroundRb.bodyType = RigidbodyType2D.Dynamic;
                bigGroundRb.mass = 3f;
                bigGroundRb.gravityScale = 3f;
            }
        }

    }

    // Player Respawn when the player dies
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.2f);
        RestartScene(); // Call the function to restart the scene
    }

    // Function to restart the scene
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}