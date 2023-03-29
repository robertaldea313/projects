using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    public float speed;
    
    Rigidbody2D rb;
    private bool Grounded=false;
    public float jumpSpeed;
    public GameObject GroundCheck;
    public float jumpPressTime;
    private float jumpPress;

    private bool facingRight = true;
    public Animator anim;
    

    void Start()
    {
      rb = GetComponent<Rigidbody2D>(); 
      anim.SetBool("IsMoving",false); 

    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        if(horizontalMove<0 && facingRight)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;  
        }
        else
        {
            if(horizontalMove>0 && facingRight==false)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    facingRight = true; 
                }
        }
        if(horizontalMove!=0)
        {
            anim.SetBool("IsMoving",true);
        }
        else
        {
            anim.SetBool("IsMoving",false);
        }
            
        transform.position=transform.position + new Vector3(horizontalMove*speed*Time.fixedDeltaTime, 0, 0);
    }

    void Update()
    {
        if(jumpPress>0)
            jumpPress-=Time.fixedDeltaTime;
        if(Input.GetKeyDown("w"))
            {
                jumpPress=jumpPressTime;
            }    

        if(jumpPress>0 && Grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            Grounded = false;
            anim.SetBool("IsGrounded",false);
            FindObjectOfType<AudioManager>().Play("Jump"); 
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {   
            Grounded = true;
            anim.SetBool("IsGrounded",true);
        }    
    }
}
