using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float SpeedValue;
    public float AccelerateDist;
    private float speed;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }


    void FixedUpdate()
    {   
        if(Vector3.Distance(player.transform.position, transform.position)>=AccelerateDist)
            speed=SpeedValue+5;
        else
        {
            speed=SpeedValue;
        }    
         transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,transform.position.y,transform.position.z), speed*Time.fixedDeltaTime);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(other.gameObject);
        }
    }
}
