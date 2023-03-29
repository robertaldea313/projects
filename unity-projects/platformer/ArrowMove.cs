using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float projectileSpeed;

    void Update()
    {
        transform.position = new Vector3(transform.position.x - projectileSpeed*Time.deltaTime, transform.position.y, 0);   
    }
}
