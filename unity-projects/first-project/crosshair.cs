using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
   private Vector3 mousePosition;
   private float moveSpeed = 100f;
   public Animator anim;

   private float Delay;

  void Update()
  {   if(Delay>0)
          Delay-= Time.deltaTime; 
      if(Delay<=0)
           anim.Play("OnIdle");

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
      if (Input.GetMouseButtonDown(0))
        {
         anim.Play("OnClick");
         Delay = 0.2f;
        }   

     }
}  
