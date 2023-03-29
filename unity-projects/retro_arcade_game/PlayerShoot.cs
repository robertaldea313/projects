using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{
    public float speed = 5f;
    public Quaternion rotation;
    float angle;
    Vector3 direction;

    public Rigidbody2D Bullet;
    public GameObject firePoint;
    public float thrust;

    SpriteRenderer player;
    Rigidbody2D playerRB;
    public float recoil;

    SpriteRenderer gun;
    bool facingRight = true;

    ParticleSystem gunFire;
    public Animator cameraShake;

    public float recoilStop;
    float recoilTimer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        gun = GameObject.Find("PlayerWeapon").GetComponent<SpriteRenderer>();
        gunFire = GameObject.Find("GunFire").GetComponent<ParticleSystem>();
    }
    private void Update()
    {

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            cameraShake.Play("smallShake");
        }

        if (facingRight)
        {
            if (angle > 0 || angle < -180)
            {
                player.flipX = true;
                gun.flipX = true;
                facingRight = false;
            }
        }
        else
        {
            if (angle < 0 && angle > -180)
            {
                player.flipX = false;
                gun.flipX = false;
                facingRight = true;
            }
        }

        if(recoilTimer >0)
        {
            recoilTimer -= Time.deltaTime;
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        }

    }
    void Fire()
    {
        Rigidbody2D instBullet = (Rigidbody2D)Instantiate(Bullet, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, firePoint.transform.position.y), transform.rotation);
        instBullet.velocity = transform.up * thrust;
        playerRB.velocity = transform.up * -recoil;

        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        recoilTimer = recoilStop;
        gunFire.Play();
        FindObjectOfType<AudioManager>().Play("PlayerShoot");
    }
}
