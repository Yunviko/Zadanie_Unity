using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 7;
    public float jumpForce = 10;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;

    private bool isDashed;
    private float dashTime = 0f;
    

    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public GroundChecker groundChecker;
    public PlayerStats stats;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (stats.isDead) return;

        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (moveInput != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {           
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.F) && !isDashed)
        {
            isDashed = true;
            dashTime = dashDuration;
        }

        if (isDashed)
        {
            rb.velocity = new Vector2(moveInput * dashSpeed, rb.velocity.y);
            dashTime -= Time.deltaTime;

            if (dashTime <= 0)
            {
                isDashed = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }
    
    
}
