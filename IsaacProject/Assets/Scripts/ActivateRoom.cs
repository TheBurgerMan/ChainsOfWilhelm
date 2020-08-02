using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom : MonoBehaviour
{
    public Room room;

    private void Start()
    {
        room = gameObject.GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            room.isActive = true;
            if (room.isCompleted == false)
            {
                foreach (var door in room.doors)
                {
                    //Debug.Log("Closing Doors!");
                    door.gameObject.GetComponent<Door>().DoorControl("Close");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            room.isActive = false;
        }
    }
}
