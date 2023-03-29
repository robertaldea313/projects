using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageScript : MonoBehaviour
{
    public float speed;
    GameObject player;
    bool facingRight = true;

    Vector2 pos;
    Vector2 target;

    float timer;
    public float time = 0.1f;

    public float minTime;
    public float maxTime;
    private float MoveTimer;

    public Animator animator;
    
    void Start()
    {
        MoveTimer=Random.Range(minTime,maxTime);
        player = GameObject.Find("Player");
        timer = time;
    }


    void Update()
    {
        if(MoveTimer<=0)
       {
          animator.SetTrigger("Shoot");
       }
       else
    {
        target = player.transform.position;
        pos = transform.position ;
        if (target.x >= pos.x+0.2f)
        {
            pos.x += speed * Time.deltaTime;
            timer = time;
            transform.position = pos;
            if (facingRight == false)
               {
                  transform.localRotation = Quaternion.Euler(0, 0, 0);
                  facingRight = true;
               }
        }
        else if (target.x <= pos.x-0.2f)
        {
            pos.x -= speed * Time.deltaTime;
            timer = time;
            transform.position = pos;
            if (facingRight == true)
               {
                 transform.localRotation = Quaternion.Euler(0, 180, 0);
                 facingRight = false;  
               }
        }
        if (target.y >= pos.y+0.2f)
        {
            pos.y += speed * Time.deltaTime;
            timer = time;
            transform.position = pos;
        }
        else if (target.y <= pos.y-0.2f)
        {
            pos.y -= speed * Time.deltaTime;
            timer = time;
            transform.position = pos;
        }
     }
    }  
}
