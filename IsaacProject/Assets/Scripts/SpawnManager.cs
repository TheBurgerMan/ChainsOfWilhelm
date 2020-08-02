using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PrefabManager layouts;
    //private Vector3 offset = new Vector3(-8, 4, 0);
    private int randomRoomNo;
    private bool hasSpawned;
    [Tooltip("Number corresponding to respective room to be spawned\n1: Top door\n2: Bottom door\n3: Left door\n4: Right door")]
    public int spawnDir;

    void Start()
    {
        Destroy(gameObject, 5f);
        layouts = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
        Invoke("SpawnRoom", .5f);
    }

    public void SpawnRoom()
    {
        if (!hasSpawned)
        {
            if (spawnDir == 1)
            {
                randomRoomNo = Random.Range(0, layouts.topRooms.Length);
                GameObject room = Instantiate(layouts.topRooms[randomRoomNo], transform.position, Quaternion.identity);
                int randomInterior = Random.Range(0, layouts.roomInteriors.Length);
                GameObject roomInterior = Instantiate(layouts.roomInteriors[randomInterior], transform.position, Quaternion.identity);
                roomInterior.transform.parent = room.transform;
                //Spawn room with Top Door
            }
            else if (spawnDir == 2)
            {
                randomRoomNo = Random.Range(0, layouts.bottomRooms.Length);
                GameObject room = Instantiate(layouts.bottomRooms[randomRoomNo], transform.position, Quaternion.identity);
                int randomInterior = Random.Range(0, layouts.roomInteriors.Length);
                GameObject roomInterior = Instantiate(layouts.roomInteriors[randomInterior], transform.position, Quaternion.identity);
                roomInterior.transform.parent = room.transform;
                //Spawn room with Bottom Door
            }
            else if (spawnDir == 3)
            {
                randomRoomNo = Random.Range(0, layouts.leftRooms.Length);
                GameObject room = Instantiate(layouts.leftRooms[randomRoomNo], transform.position, Quaternion.identity);
                int randomInterior = Random.Range(0, layouts.roomInteriors.Length);
                GameObject roomInterior = Instantiate(layouts.roomInteriors[randomInterior], transform.position, Quaternion.identity);
                roomInterior.transform.parent = room.transform;
                //Spawn room with Left Door
            }
            else if (spawnDir == 4)
            {
                randomRoomNo = Random.Range(0, layouts.rightRooms.Length);
                GameObject room = Instantiate(layouts.rightRooms[randomRoomNo], transform.position, Quaternion.identity);
                int randomInterior = Random.Range(0, layouts.roomInteriors.Length);
                GameObject roomInterior = Instantiate(layouts.roomInteriors[randomInterior], transform.position, Quaternion.identity);
                roomInterior.transform.parent = room.transform;
                //Spawn room with Right Door
            }
            hasSpawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            //Destroy(gameObject);
            if (collision.GetComponent<SpawnManager>().hasSpawned == false && hasSpawned == false)
            {
                GameObject closedRoom = Instantiate(layouts.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            hasSpawned = true;

        }
    }
}
