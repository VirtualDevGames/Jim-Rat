using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform groundCheck;
    private LayerMask groundLayer;
    private Animator animator;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    private bool isGrounded;
    private bool hasDoubleJump;
    private int jumpCounter = 1;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundCheck = transform.Find("Ground Check").transform;
        groundLayer = LayerMask.GetMask("Ground");
    }
    // Update is called once per frame
    void Update()
    {
        // Give velocity to player
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Walking parameters
        if (rb.velocity.magnitude > 0)
            animator.SetBool("isWalking", true);
        else if (rb.velocity.magnitude == 0)
            animator.SetBool("isWalking", false);

        // Flip
        if (!isFacingRight && horizontal > 0f) {
            Flip();
        }
        else if(isFacingRight && horizontal < 0f) {
            Flip();
        }

        IsGrounded();
    }

    // Read input value for moving
    public void Move(InputAction.CallbackContext ctx) {
        horizontal = ctx.ReadValue<Vector2>().x;
    }

    // Check the groundCheck object for overlap with ground
    private bool IsGrounded() {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded) {
            jumpCounter = 1;
        }

        return isGrounded;
    }

    // Turn character around by flipping the scale
    private void Flip() { 
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Jump
    public void Jump(InputAction.CallbackContext ctx) {
        if(ctx.performed && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (ctx.canceled && rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (ctx.performed && !IsGrounded() && (jumpCounter > 0)) {
            jumpCounter--;
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }


    // Getters Setters
    public bool HasDoubleJump {
        get {
            return hasDoubleJump;
        }
        set {
            hasDoubleJump = value;
        }
    }
}
