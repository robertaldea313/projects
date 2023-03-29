using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    float topBound = 14f;
    float botBound = -14f;
    float leftBound = -21f;
    float rightBound = 21f;
    void Update()
    {
        if (transform.position.x >= rightBound)
        {
            transform.position = new Vector3(leftBound + 1, transform.position.y, transform.position.z);
        }
        else
        if (transform.position.x <= leftBound)
        {
            transform.position = new Vector3(rightBound - 1, transform.position.y, transform.position.z);
        }

        if (transform.position.y >= topBound)
        {
            transform.position = new Vector3(transform.position.x, botBound + 1, transform.position.z);
        }
        else
        if (transform.position.y <= botBound)
        {
            transform.position = new Vector3(transform.position.x, topBound - 1, transform.position.z);
        }
    }
}
