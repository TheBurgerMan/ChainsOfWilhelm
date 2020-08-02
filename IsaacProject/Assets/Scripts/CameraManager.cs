using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PrefabManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    private void FixedUpdate()
    {
        foreach (GameObject temproom in manager.roomList)
        {
            Room room = temproom.GetComponent<Room>();
            if (room.isActive)
            {
                Vector2 smoothPosition = Vector2.Lerp(transform.position, room.transform.position, 5f * Time.deltaTime);
                transform.position = smoothPosition;
            }
        }
    }
}
