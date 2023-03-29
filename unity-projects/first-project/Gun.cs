using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float speed = 3f;
    public float ProjectileSpeed;


    Rigidbody2D rb;
    Rigidbody2D dash;


    public float DashSpeed;
    private float DashTimer = 0;
    public float DashLength;
    public float DashCooldown;
    private float DTimer;
    private float FlashTime;


    private Quaternion rotation;
    private float angle;
    private Vector3 direction;
    public GameObject bullet;
    public int MaxAmmo;
    private int CurrentAmmo;
    public float ReloadTime;
    private float Timer = 0;
    bool facingright = true;


    public Animator animator;


    public GameObject player;
    public GameObject dashTrail;
    public GameObject reloadTrail;
    public SpriteRenderer muzzleFlash;
    public Text ammoCounter;

    bool IsDashing;

    private int MinDamage = 2;
    private int MaxDamage = 5;
    private int DamageBonus = 0;

    private float sizeDefault = 1;
    

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
        dashTrail.GetComponent<TrailRenderer>().enabled=false; 
        reloadTrail.GetComponent<TrailRenderer>().enabled=false; 
        muzzleFlash.enabled = false;
        dash = player.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        ammoCounter.text = CurrentAmmo + "/" + MaxAmmo;

        if(FlashTime>0)
           FlashTime -=Time.deltaTime;
        else
          {   
           if (muzzleFlash.enabled == true)
                muzzleFlash.enabled = false;
          }         
        if(Timer>0)
            Timer -= Time.deltaTime;
        if(DashTimer>0)
        {
            DashTimer -= Time.deltaTime;
        }    
         if(DTimer>0)
         {
            DTimer -= Time.deltaTime;
         }       
        if (DashTimer<=0 && IsDashing==true)
        {    
            dash.velocity = new Vector2(0f, 0f);
            player.GetComponent<PlayerController>().SetDash(false);
            dashTrail.GetComponent<TrailRenderer>().enabled=false; 
            IsDashing=false;
        }    


        if(CurrentAmmo <= 0 && Timer<=0)
        {
            animator.SetBool("IsReloading", false);
            CurrentAmmo = MaxAmmo;
            reloadTrail.GetComponent<TrailRenderer>().enabled=false; 
        }   


        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        if (facingright == true)
           if ((angle<= -175) || (angle>=5) )
            {
                 player.transform.localRotation = Quaternion.Euler(0, 180, 0);
                 Vector3 theScale = transform.localScale;
                 theScale.x *= -1;
                 transform.localScale = theScale;
              
                 facingright = false;
            }
        if (facingright == false)
             if ((angle>= -185) && (angle<=-5))
             {
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                
                facingright= true;
             }   


        if (Input.GetMouseButtonDown(0))
        {if (CurrentAmmo>0)
           {
                Vector3 dir = direction / direction.magnitude;
                Shoot(dir);
                CurrentAmmo -=1;
                muzzleFlash.enabled = true;
                FlashTime = 0.1f;
                FindObjectOfType<AudioManager>().Play("Shoot");

                if (CurrentAmmo <=0)
                {
                    animator.SetBool("IsReloading", true);
                    FindObjectOfType<AudioManager>().Play("Reload");
                    Timer = ReloadTime;
                    reloadTrail.GetComponent<TrailRenderer>().enabled=true; 
                }      

            }    


        }
        if (Input.GetMouseButtonDown(1))
          if(DTimer<=0)
           {
            dash = player.GetComponent<Rigidbody2D>();
            dash.AddForce(transform.up * DashSpeed, ForceMode2D.Impulse);
            player.GetComponent<PlayerController>().SetDash(true);
            DashTimer = DashLength;
            DTimer = DashCooldown;
            dashTrail.GetComponent<TrailRenderer>().enabled=true;
            FindObjectOfType<AudioManager>().Play("Dash");
            IsDashing=true;
           }


        if (Input.GetKeyDown("r") && CurrentAmmo<MaxAmmo && Timer<=0)
           {
               animator.SetBool("IsReloading", true);
               FindObjectOfType<AudioManager>().Play("Reload");
               reloadTrail.GetComponent<TrailRenderer>().enabled=true; 
               CurrentAmmo = 0;
               Timer = ReloadTime;
           }   
    }           

        void Shoot(Vector2 dir)
        {
            bullet.GetComponent<BulletDamage>().SetDamage(MinDamage+DamageBonus, MaxDamage+DamageBonus, sizeDefault);
            GameObject Projectile = Instantiate(bullet, muzzleFlash.transform.position, rotation);
            rb = Projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * ProjectileSpeed, ForceMode2D.Impulse);
        }

        public void ChangeBullet(int amount, float sizeMod)
        {
            DamageBonus+=amount;
            sizeDefault+=sizeMod;
        }

}
