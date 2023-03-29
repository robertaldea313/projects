using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMovement;
    public float speed;

    int JumpCount;
    public int jumpMax;

    public float jumpForce;
    Rigidbody2D rb;


    float jumpTimer = 0;
    public float jumpDelay;

    float coyoteTimer;
    public float coyoteDelay;
    bool isGrounded;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("w"))
        {
            jumpTimer = jumpDelay;
        }
        if(jumpTimer>0)
        {
            jumpTimer -= Time.deltaTime;
        }
        if(coyoteTimer>0)
        {
            coyoteTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if(coyoteTimer<=0 && !isGrounded && JumpCount >1)
        {
            JumpCount -= 1;
        }
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);
        if ((JumpCount>=1) && (jumpTimer > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); 
            JumpCount -= 1;
            jumpTimer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        JumpCount = jumpMax;
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        coyoteTimer = coyoteDelay;
        isGrounded = false;
    }
}
