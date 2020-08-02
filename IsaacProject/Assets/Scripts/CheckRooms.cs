using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckRooms : MonoBehaviour
{
    private PrefabManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PrefabManager").GetComponent<PrefabManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isDungeonComplete();
    }

    void isDungeonComplete()
    {
        if (manager.roomList.Count == manager.completedRooms.Count)
        {
            SceneManager.LoadScene(3);
        }
    }
}
