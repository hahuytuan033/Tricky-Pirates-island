using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float jumpForce = 5f;
    public Rigidbody2D rb;
    float horizontalMovement;

    // variable jump
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;

    // variable anim
    private Animator anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);

        //Player Jump
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.45f, 0.05f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity= new Vector2(rb.linearVelocity.x, jumpForce);
        }

        Animation(); // call the animation function
    }

    private void Animation()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }
}
