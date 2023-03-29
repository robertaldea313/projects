using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    GameObject player;

    Vector2 target;

    float timer;
    public int Damage;
    public float LifeTime;
    public Animator animator;
    private bool Stop=false;

    void Start()
    {
        player = GameObject.Find("Player");
        timer = LifeTime;
        target = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     if(Vector2.Distance(transform.position,target)>=0.1)  
     {
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
     }   
     else
      {
        if(Stop==false)
        {      
         animator.SetTrigger("End");
         Stop=true;
        } 

        if(timer>0)  
          timer-=Time.deltaTime;
        else
        {
          Destroy(gameObject); 
        }  

      }  
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.ChangeHealth(-Damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
