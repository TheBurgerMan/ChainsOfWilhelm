using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OpenDoor")
        {
            collision.gameObject.GetComponentInParent<Room>().doors.Remove(collision.gameObject);
            Destroy(collision.gameObject, 5f);
            //Debug.Log("Door is dead. Mismatch");
            //room.openDoors.Remove(gameObject);
            //Destroy(gameObject, 5f);
        }
    }
}
