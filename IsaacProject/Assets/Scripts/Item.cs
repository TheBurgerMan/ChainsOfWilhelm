using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Vector2 radPos;
    private Notification notification;
    private string notifText;
    private int itemType;
    private CircleCollider2D col;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

        col = gameObject.GetComponent<CircleCollider2D>();
        notification = GameObject.FindGameObjectWithTag("NotificationText").GetComponent<Notification>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        radPos = transform.position + (Random.insideUnitSphere * 1f);
        IdentifyItem();
        StartCoroutine(DelayCollider());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector2.Lerp(transform.position, radPos, 5 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            notification.DisplayText(notifText);
            Effect(itemType);
        }
    }

    void IdentifyItem()
    {
        switch (gameObject.tag)
        {
            case "HealthItem":
                notifText = "";
                itemType = 1;
                break;
            case "SpeedItem":
                notifText = "+Speed!";
                itemType = 2;
                break;
            case "ShotRangeItem":
                notifText = "+Range!";
                itemType = 3;
                break;
            case "FireRateItem":
                notifText = "+Fire-rate!";
                itemType = 4;
                break;
            case "DamageItem":
                notifText = "+Damage!";
                itemType = 5;
                break;
        }
    }

    IEnumerator DelayCollider()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1);
        col.enabled = true;
    }

    void Effect(int itemType)
    {
        SoundManager.PlaySound("Pickup");
        switch (itemType)
        {
            case 1:
                if (player.health < 6)
                {
                    player.health += 1;
                    Destroy(gameObject);
                }
                if (player.health > 6) {
                    player.health = 6;
                }
                break;
            case 2:
                player.playerSpeed += 25;
                Destroy(gameObject);
                break;
            case 3:
                player.fireLifeSpan += .5f;
                Destroy(gameObject);
                break;
            case 4:
                player.fireRate -= .10f;
                Destroy(gameObject);
                break;
            case 5:
                player.fireDamage += 5;
                Destroy(gameObject);
                break;
                
        }
    }
}
