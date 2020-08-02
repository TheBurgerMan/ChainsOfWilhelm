using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRoomsEnabler : MonoBehaviour
{
    public GameObject obj;

    private void Start()
    {
        Invoke("Enable", 5f);
    }
    void Enable()
    {
        obj.SetActive(true);
    }

}
