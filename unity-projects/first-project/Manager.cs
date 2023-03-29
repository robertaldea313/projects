using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Bullet(Clone)"), 2);
        Destroy(GameObject.Find("spark(Clone)"), 0.5f);
        Destroy(GameObject.Find("EnemyDeath(Clone)"), 0.5f);
        Destroy(GameObject.Find("SpawnerEffect(Clone)"), 2f);
    }
}
