using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject projectile;
    public GameObject spawner;

    public float projectileDelayMin;
    public float projectileDelayMax;
    private float projectileTimer;

    public float spawnDelay;
    private float spawnTimer = 0;
    bool spawnProjectile=false;

    public float Offset;

    Vector3 pos;

    void Start()
    {
       projectileTimer =Random.Range(projectileDelayMin,projectileDelayMax);
       spawner.GetComponent<Renderer>().enabled = false;  
    }

    void Update()
    {
       if(projectileTimer>0)
            projectileTimer-=Time.deltaTime;
        else
        {
            spawnTimer = spawnDelay;
            spawnProjectile = true;
            spawner.GetComponent<Renderer>().enabled = true; 
            pos = new Vector3(transform.position.x + Offset, transform.position.y, 0);
            Instantiate(projectile, pos, Quaternion.identity);
            projectileTimer =Random.Range(projectileDelayMin,projectileDelayMax);
            this.GetComponent<CameraController>().FreezeY(false);
        }
        if(spawnTimer>0)
            spawnTimer-=Time.deltaTime;
        else
            if(spawnProjectile)
            {
                spawnProjectile = false;
                spawner.GetComponent<Renderer>().enabled = false; 
                this.GetComponent<CameraController>().FreezeY(true);  
            }
        
    }
}
