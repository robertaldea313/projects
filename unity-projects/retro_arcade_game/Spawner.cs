using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawner;
    public float spawnDelay;
    float spawnTimer;

    public float MaxSpawn;
    float spawnNumber;

    public int arraySize;

    public GameObject[] enemy;

    GameObject[] enemyCounter;

    public GameObject WarningSign;

    private void Awake()
    {
        spawnTimer = spawnDelay; 
    }
    void Update()
    {
        enemyCounter = GameObject.FindGameObjectsWithTag("Enemy");
        if (spawnTimer>0)
        {
            if (spawnTimer > spawnDelay / 8 && enemyCounter.Length == 0)
            {
                spawnTimer = spawnDelay / 8;
            }
            else
            if (spawnTimer <= spawnDelay / 8)
            {
                WarningSign.SetActive(true);
            }
            spawnTimer -= Time.deltaTime;

        }
        else
        {   
            spawnTimer = spawnDelay;
            spawnNumber = Random.Range(1, MaxSpawn);
            for (int i = 0; i < spawnNumber; i++)
            {
                Instantiate(enemy[Random.Range(0, arraySize-1)], spawner[Random.Range(1, arraySize)].transform.position, transform.rotation);
            }
            WarningSign.SetActive(false);

        }
    }
}
