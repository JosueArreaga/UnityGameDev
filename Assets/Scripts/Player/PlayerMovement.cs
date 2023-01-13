using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    public Rigidbody2D rb;
    public Animator playerAnimator;
    public float speed = 200f;
    public float JumpForce = 5;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isFacingRight = true;

    int numberOfJumps = 0;
    bool isGrounded;
    float direction = 0;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        playerAnimator.SetBool("isJumping", isGrounded);
        rb.velocity = new Vector2(direction * Time.deltaTime * speed, rb.velocity.y);
        playerAnimator.SetFloat("Speed", Mathf.Abs(direction));

        if(isFacingRight && direction <0 || !isFacingRight && direction > 0)
        {
            isFacingRight = !isFacingRight;
            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector2 (transform.localScale.x *-1, transform.localScale.y); 
    }

    void Jump()
    {
        if(isGrounded)
        {
            numberOfJumps = 0;
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("Jump");
        }
        else
        {
            if(numberOfJumps == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                numberOfJumps++;
                AudioManager.instance.Play("Jump");
            }
        }

    }
}
