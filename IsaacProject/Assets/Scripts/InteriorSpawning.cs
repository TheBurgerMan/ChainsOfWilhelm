using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> spawnPoints;
    public Room room;
    public int wavesLeft = 99;
    private bool enemiesPresent;
    void Start()
    {
        wavesLeft = Random.Range(1, 3);
        room = GetComponentInParent<Room>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (room.isActive && room.isCompleted == false && enemiesPresent == false && wavesLeft > 0)
        {
            StartCoroutine(DelaySpawn());
            foreach (var spawn in spawnPoints)
            {
                Debug.Log("SpawnEnemy");
                spawn.GetComponent<InteriorSpawn>().Spawn();
            }
            wavesLeft--;
            enemiesPresent = true;
        }
        if (room.enemies.Count.Equals(0))
        {
            enemiesPresent = false;
        }
        if (wavesLeft <= 0 && !enemiesPresent)
        {
            room.isCompleted = true;
        }
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(1);
    }
}
