using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    bool Spawned = false;
    public GameObject platform;
    Vector3 pos;
    public float limitTop;
    public float limitBot;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(Spawned==false)
        {
            Spawned=true;
            pos = new Vector3
            (
                transform.position.x + Random.Range(5,11),
                Mathf.Clamp(transform.position.y + Random.Range(-2, 2f),limitBot,limitTop),
                transform.position.z
            );
            Instantiate( platform, pos, Quaternion.identity); 
            GameObject.Find("Score").GetComponent<Score>().ScoreIncrease();

        }
    }

}
