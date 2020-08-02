using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private PrefabManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
        manager.roomList.Add(gameObject);
    }
}
