using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 6;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    public Vector2 shootVector;
    private SpriteRenderer rndr;

    public GameObject fireballPrefab;
    public float fireRate;
    public float fireLifeSpan;
    public int fireDamage;
    private float lastShoot;
    public bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        rndr = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        shootVector = new Vector2(Input.GetAxisRaw("ShootHorizontal"), Input.GetAxisRaw("ShootVertical"));

        if ((shootVector != Vector2.zero) && Time.time > (lastShoot + fireRate))
        {
            Shoot();
            lastShoot = Time.time;
        }
        Movement(moveVector);
        UpdateSprite();
    }

    void Movement(Vector2 moveVector)
    {
        rb.velocity = moveVector.normalized * playerSpeed * Time.deltaTime;
        
    }

    void UpdateSprite()
    {
        if (moveVector.x < 0)
        {
            rndr.flipX = true;
        }
        if (moveVector.x > 0)
        {
            rndr.flipX = false;
        }
    }

    void Shoot()
    {
        SoundManager.PlaySound("Shoot");
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            SoundManager.PlaySound("Damaged");
            health = health - 1;
            if (health <= 0)
            {
                health = 0;
                SceneManager.LoadScene(2);
            }
        }
        StartCoroutine(Invincibility()) ;
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
    }
}
