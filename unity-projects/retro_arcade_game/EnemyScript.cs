using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool isGrounded;
    bool facingRight = true;
    public float speed;

    public float moveDelay;
    float moveTimer;
    GameObject player;
    SpriteRenderer enemy;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = this.GetComponent<SpriteRenderer>();
        speed += Random.Range(-1f, 1f);
        var sizeRandomizer = Random.Range(-0.15f, 0.15f);
        transform.localScale = new Vector3(transform.localScale.x + sizeRandomizer, transform.localScale.y + sizeRandomizer, transform.localScale.z + sizeRandomizer);
    }

    void FixedUpdate()
    {
        if(isGrounded || moveTimer>=0)
        {
            if(transform.position.y<player.transform.position.y+2 && transform.position.y > player.transform.position.y - 2)
                if(transform.position.x>=player.transform.position.x && facingRight)
                {
                    speed *= -1;
                    facingRight = false;
                    enemy.flipX = true;
                }
                else
                if (transform.position.x <= player.transform.position.x && !facingRight)
                {
                    speed *= -1;
                    facingRight = true;
                    enemy.flipX = false;
                }
            transform.position = new Vector3(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y, transform.position.z);
        }
        
    }

    private void Update()
    {
        if (moveTimer>=0)
        {
            moveTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<Canvas>().GetComponent<PauseMenu>().Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        moveTimer = moveDelay;
    }
}
