using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public int bulletHealth;
    Rigidbody2D bulletRB;

    public GameObject EnemyDeathParticle;
    public ParticleSystem wallHit;
    public GameObject destroyParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(EnemyDeathParticle, collision.transform.position, transform.rotation);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("enemyDeath");
            FindObjectOfType<ScoreManager>().ScoreIncrease();
        }
        else
            if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Canvas>().GetComponent<PauseMenu>().Death();
        }
        FindObjectOfType<AudioManager>().Play("ballBounce");
        bulletHealth -= 1;
        if (bulletHealth <= 0)
        {
            Instantiate(destroyParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
            wallHit.Play();
    }

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bulletRB.velocity = new Vector2(Mathf.Clamp(bulletRB.velocity.x, -15, 15), Mathf.Clamp(bulletRB.velocity.y, -15, 15));
    }
}
