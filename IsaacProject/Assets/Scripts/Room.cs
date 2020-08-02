using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isActive;
    public bool isCompleted = false;
    public List<GameObject> enemies;
    public List<GameObject> items;
    public List<GameObject> doors;

    public PrefabManager manager;



    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    private void FixedUpdate()
    {
        if (isCompleted)
        {
            if (!manager.completedRooms.Contains(gameObject))
            {
                manager.completedRooms.Add(gameObject);
            }
            
            foreach (var door in doors)
            {
                door.GetComponent<Door>().DoorControl("Open");
            }
        }
    }

}
