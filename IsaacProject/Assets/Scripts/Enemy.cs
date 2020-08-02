using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Room room;
    private GameObject player;
    private SpriteRenderer rndr;
    public GameObject fireBall;
    public float bulletSpeed;
    public float lifeTime;
    public int health;
    public bool isRanged;
    private float lastShoot;
    public float fireRate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rndr = gameObject.GetComponent<SpriteRenderer>();
        room = gameObject.GetComponentInParent<Room>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Time.time > (lastShoot + fireRate))
        //{
        //    Shoot();
        //    lastShoot = Time.time;
        //}
        FlipSprite();
        CheckHealth();
    }
    void FlipSprite()
    {
        
        if (player.transform.position.x < transform.position.x)
        {
            rndr.flipX = true;
        }
        else
        {
            rndr.flipX = false;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    
    void CheckHealth()
    {
        if (health <= 0)
        {
            SoundManager.PlaySound("EnemyDeath");
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        room.enemies.Remove(gameObject);
    }

    void Shoot()
    {
        //GameObject bullet1 = Instantiate(fireBall, transform.position, Quaternion.identity);
        //bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * Time.deltaTime);
        //Destroy(bullet1, lifeTime);

        //GameObject bullet2 = Instantiate(fireBall, transform.position, Quaternion.identity);
        //bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed * Time.deltaTime);
        //Destroy(bullet2, lifeTime);

        //GameObject bullet3 = Instantiate(fireBall, transform.position, Quaternion.identity);
        //bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * Time.deltaTime, 0);
        //Destroy(bullet3, lifeTime);

        //GameObject bullet4 = Instantiate(fireBall, transform.position, Quaternion.identity);
        //bullet1.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed * Time.deltaTime, 0);
        //Destroy(bullet4, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
