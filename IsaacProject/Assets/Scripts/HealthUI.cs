using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Sprite[] healthSprites;
    private PlayerController player;
    private Image spriteImage;

    // Start is called before the first frame update
    void Start()
    {
        spriteImage = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        switch (player.health)
        {
            case 6:
                spriteImage.sprite = healthSprites[6];
                break;
            case 5:
                spriteImage.sprite = healthSprites[5];
                break;
            case 4:
                spriteImage.sprite = healthSprites[4];
                break;
            case 3:
                spriteImage.sprite = healthSprites[3];
                break;
            case 2:
                spriteImage.sprite = healthSprites[2];
                break;
            case 1:
                spriteImage.sprite = healthSprites[1];
                break;
            case 0:
                spriteImage.sprite = healthSprites[0];
                break;
            default:
                break;
        }
    }
}
