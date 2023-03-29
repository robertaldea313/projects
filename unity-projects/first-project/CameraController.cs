using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject crosshair;
    Vector3 mousePosition;
    Vector3 playerPosition;

    public float limitBottom;
    public float limitLeft;
    public float limitRight;
    public float limitTop;
    void Start()
    {
    }

    void FixedUpdate()
    {
        mousePosition = crosshair.transform.position;
        playerPosition = player.transform.position;
        transform.position = Vector3.Lerp(playerPosition, mousePosition, 0.3f) +new Vector3(0, 0 , -10);
        transform.position = new Vector3   
             (
                  Mathf.Clamp (transform.position.x, limitLeft, limitRight),
                  Mathf.Clamp (transform.position.y, limitBottom, limitTop),
                  transform.position.z
            );
    }
}
