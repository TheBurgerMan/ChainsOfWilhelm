using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;
    public float speed;
    public GameObject remnantPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Destroy(gameObject, player.fireLifeSpan);
        if (player.shootVector.x > 0)
        {
            Debug.Log("FireRight");
            Fire("Right");
        }
        if (player.shootVector.x < 0)
        {
            Debug.Log("FireLeft");
            Fire("Left");
        }
        if (player.shootVector.y > 0)
        {
            Debug.Log("FireUp");
            Fire("Up");
        }
        if (player.shootVector.y < 0)
        {
            Debug.Log("FireDown");
            Fire("Down");
        }
    }


    void Fire(string direction)
    {
        switch (direction)
        {
            case "Up":
                rb.velocity = new Vector2(0, speed * Time.deltaTime);
                break;
            case "Down":
                rb.velocity = new Vector2(0, -speed * Time.deltaTime);
                break;
            case "Left":
                rb.velocity = new Vector2(-speed * Time.deltaTime, 0);
                break;
            case "Right":
                rb.velocity = new Vector2(speed * Time.deltaTime, 0);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Door")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(player.fireDamage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject remnant = Instantiate(remnantPrefab, transform.position, Quaternion.identity);
        Destroy(remnant, .5f);
    }
}
