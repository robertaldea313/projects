using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    GameObject player;
    bool facingRight = true;
    public Animator animator;


    Vector2 pos;
    Vector2 target;

    float timer;
    public float time = 0.1f;
    
    void Start()
    {
        player = GameObject.Find("Player");
        timer = time;
        animator.SetBool("IsMoving", false);
    }


    void Update()
    {
        if(timer<=0)
        {
            target = player.transform.position;
            timer=time;
        }    
        else
        {
            timer-=Time.deltaTime;
        }
        pos = transform.position ;
        if (target.x >= pos.x+0.2f)
        {
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            animator.SetBool("IsMoving", true);
            if (facingRight == false)
               {
                  transform.localRotation = Quaternion.Euler(0, 0, 0);
                  facingRight = true;
               }
        }
        else if (target.x <= pos.x-0.2f)
        {
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
            animator.SetBool("IsMoving", true);
            if (facingRight == true)
               {
                 transform.localRotation = Quaternion.Euler(0, 180, 0);
                 facingRight = false;  
               }
        }
        if (target.y >= pos.y+0.2f)
        {
            pos.y += speed * Time.deltaTime;
            transform.position = pos;
            animator.SetBool("IsMoving", true);
        }
        else if (target.y <= pos.y-0.2f)
        {
            pos.y -= speed * Time.deltaTime;
            transform.position = pos ;
            animator.SetBool("IsMoving", true);
        }
    }

}
