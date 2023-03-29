using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapException : MonoBehaviour
{
    float topBound = 14f;
    float botBound = -14f;
    float leftBound = -21f;
    float rightBound = 21f;

    public TrailRenderer exception;
    float shortTimer;
    public float shortDelay;

    void Update()
    {
        if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3(leftBound + 1, transform.position.y, transform.position.z);
            shortTimer = shortDelay;
            exception.enabled = false;
        }
        else
        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector3(rightBound - 1, transform.position.y, transform.position.z);
            shortTimer = shortDelay;
            exception.enabled = false;
        }

        if (transform.position.y >= topBound)
        {
            transform.position = new Vector3(transform.position.x, botBound + 1, transform.position.z);
            shortTimer = shortDelay;
            exception.enabled = false;
        }
        else
        if (transform.position.y <= botBound)
        {
            transform.position = new Vector3(transform.position.x, topBound - 1, transform.position.z);
            shortTimer = shortDelay;
            exception.enabled = false;
        }
        if(shortTimer>0)
        {
            shortTimer -= Time.deltaTime;
        }
        else
            exception.enabled = true;
    }
}
