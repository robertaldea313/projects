using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float MaxHealth;
    private float CurrentHealth;

    public float IFrames;
    private float ITimer = 0;
    public Animator animator;
    Vector3 moving = new Vector3(0,0,0);

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthDisplay;

    public float limitBottom;
    public float limitLeft;
    public float limitRight;
    public float limitTop;

    bool Dash;

    void Start()
    {
        CurrentHealth = MaxHealth; 
        slider.value = CurrentHealth; 
        slider.maxValue = CurrentHealth;  
        fill.color = gradient.Evaluate(1f); 
    }

    void FixedUpdate()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");
        moving = transform.position;
        transform.position = transform.position + new Vector3(HorizontalMove * Time.fixedDeltaTime * speed, VerticalMove*Time.fixedDeltaTime* speed, 0);
        transform.position = new Vector3   
             (
                  Mathf.Clamp (transform.position.x, limitLeft, limitRight),
                  Mathf.Clamp (transform.position.y, limitBottom, limitTop),
                  transform.position.z
            );
        if(moving !=transform.position)
             animator.SetBool("IsMoving", true); 
        else
        {
          animator.SetBool("IsMoving", false);   
        }        
    }

    void Update()
    {
        if (ITimer>0)
          ITimer-=Time.deltaTime;  
        slider.value = CurrentHealth;  
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if(CurrentHealth>MaxHealth)
                CurrentHealth=MaxHealth; 
        healthDisplay.text = ""+CurrentHealth;          

    }

    public void ChangeHealth(int Amount)
    {
     if(Amount<0)
     {   
        if (ITimer <=0 )
        {   
            CurrentHealth += Amount;
            ITimer = IFrames;
            FindObjectOfType<AudioManager>().Play("PlayerHit");
        }
     }
      else
      {
          CurrentHealth+=Amount;
      }         
    }

    public void SetDash(bool IsDashing)
    {
        Dash=IsDashing;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     if(Dash)
        {if(other.gameObject.CompareTag("Enemy"))
            {   
                other.GetComponent<EnemyHealth>().ExecuteOnDash();
                ChangeHealth(5);
            }    
        }   
    }
}
