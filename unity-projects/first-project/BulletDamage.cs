using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
     private int DamageAdded=0;

     public int MinDamage;
     public int MaxDamage;

     private bool Hit=false;
     
     public GameObject spark;
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth controller = other.GetComponent<EnemyHealth>();
         Debug.Log("Bonus Damage " + DamageAdded);

        if (controller != null)
        {
            if(Hit==false)
            {
                controller.ChangeHealth(-Random.Range(MinDamage,MaxDamage)-DamageAdded);
                Destroy(gameObject);
                Instantiate(spark, transform.position, transform.rotation);
                Hit=true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
    public void SetDamage(int MinValue, int MaxValue, float size)
    {
        MinDamage=MinValue;
        MaxDamage=MaxValue;
        transform.localScale= new Vector3(size, size, 1);
        Debug.Log("Min Value " + MinDamage + "Max Value" + MaxDamage);
     }

}