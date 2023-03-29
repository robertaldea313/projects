using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    private float CurrentHealth;
    public Animator animator;
    public GameObject DeathParticle;
    public GameObject EnemyMain;
    private float shortTimer;
    private Shake shake;
    public bool IsSwarm;


    void Start()
    {
        CurrentHealth = MaxHealth; 
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();
    }
    void Update()
    {
        if(CurrentHealth<=0)
        {
             Destroy(EnemyMain);
             Instantiate(DeathParticle, transform.position, Quaternion.identity);
        } 
    }
     public void ChangeHealth(int Amount)
    {
            CurrentHealth += Amount; 
            if(CurrentHealth>0)
            {
               FindObjectOfType<AudioManager>().Play("EnemyHit");
               shake.CamShake();
               animator.SetTrigger("IsHit");
            }   
            else
            {
               FindObjectOfType<AudioManager>().Play("EnemyDeath");
                if(IsSwarm)
                    shake.CamShake();
                else
                {
                   shake.StrongCamShake();    
                }
            }     
    }

    public void ExecuteOnDash()
    {
        if(CurrentHealth<=MaxHealth)
        {
            Destroy(EnemyMain);
            Instantiate(DeathParticle, transform.position, Quaternion.identity);
            shake.StrongCamShake();   
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
        }

    }
}
