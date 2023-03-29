using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    public bool FollowY=false;
    public float Offset;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {   
        if(FollowY==false)
           transform.position = new Vector3(player.transform.position.x + Offset, transform.position.y, -10);
        else
        {
            transform.position = new Vector3(player.transform.position.x + Offset, player.transform.position.y, -10);
        }   
    }

    public void FreezeY(bool freeze)
    {
        FollowY = freeze;
    }
}
