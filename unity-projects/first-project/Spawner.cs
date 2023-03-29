using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float LimitX;
    public float LimitY;
    private float posX;
    private float posY;
    public float Delay;
    private float Timer = 0;
    private float SpawnTimer;
    bool IsSpawning=false;
    public GameObject[] Enemy;
    public GameObject spawnerEffect;

    bool WavePause;

    void Start()
    {
    }

    void Update()
    {
        if (Timer <=0 && IsSpawning==false)
        {   
            posX = Random.Range(-LimitX, LimitX);
            posY = Random.Range(-LimitY, LimitY);
            Instantiate(spawnerEffect, new Vector3(posX, posY,0), Quaternion.identity);
            SpawnTimer = 1f;
            IsSpawning = true;
        }
         if(SpawnTimer>0)
         {
            SpawnTimer -= Time.deltaTime;
        }
        if(SpawnTimer<=0 && IsSpawning==true)
         {
          Spawn(Random.Range(0,51));
          Timer = Delay;
          IsSpawning = false;
          FindObjectOfType<AudioManager>().Play("SpawnSound");
        }
        Timer-=Time.deltaTime;
    }


    public void Spawn(int number)
    {
     if(number<=20)    
      Instantiate(Enemy[0], new Vector2(posX, posY), Quaternion.identity);
     else
       if(number<=40) 
       {
        for (int i = 0; i <= Random.Range(4,10); i++)  
          Instantiate(Enemy[1], new Vector2(posX + Random.Range(-0.6f,0.6f), posY + Random.Range(-0.6f,0.6f)), Quaternion.identity);
       } 
     else
     {
       Instantiate(Enemy[2], new Vector2(posX, posY), Quaternion.identity);  
     }   
    }
}

