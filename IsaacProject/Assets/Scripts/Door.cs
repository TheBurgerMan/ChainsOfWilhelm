using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closedSprite;
    public bool isClosed;

    private SpriteRenderer rndr;
    private BoxCollider2D col;
    public Room room;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("EnableDoors", 10f);
        room = gameObject.GetComponentInParent<Room>();
        rndr = gameObject.GetComponent<SpriteRenderer>();
        col = gameObject.GetComponent<BoxCollider2D>();
        room.doors.Add(gameObject);


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            room.doors.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void DoorControl(string command)
    {
        if (command == "Close")
        {
            rndr.sprite = closedSprite;
            col.isTrigger = false;
        }
        if (command == "Open")
        {
            rndr.sprite = openSprite;
            col.isTrigger = true;
        }


    }
}
