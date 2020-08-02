using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorSpawn : MonoBehaviour
{
    private InteriorSpawning interior;
    private PrefabManager manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
        interior = gameObject.GetComponentInParent<InteriorSpawning>();
        interior.spawnPoints.Add(gameObject);
    }
    public void Spawn()
    {
        int randomEnemyIndex = Random.Range(0, manager.enemyPrefabs.Length);
        GameObject enemy = Instantiate(manager.enemyPrefabs[randomEnemyIndex], transform.position, Quaternion.identity);
        enemy.transform.parent = interior.transform.parent;
        interior.room.enemies.Add(enemy);
    }
}
