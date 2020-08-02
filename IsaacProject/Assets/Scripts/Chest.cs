using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite openSprite;
    private SpriteRenderer rndr;
    private PrefabManager manager;
    private bool isOpened;

    private void Start()
    {
        rndr = gameObject.GetComponent<SpriteRenderer>();
        manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isOpened)
            {
                Open();
            }
        }
    }

    private void Open()
    {
        rndr.sprite = openSprite;
        int dropAmount = Random.Range(1, 3);
        for (int i = 0; i < dropAmount; i++)
        {
            Vector3 radPos = transform.position + Random.insideUnitSphere;
            int randomDropIndex = Random.Range(0, manager.items.Length);
            Instantiate(manager.items[randomDropIndex], transform.position, Quaternion.identity);
        }
        isOpened = true;
    }
}
