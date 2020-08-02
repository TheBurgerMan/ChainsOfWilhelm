using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedRoom : MonoBehaviour
{
    private BoxCollider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        colliders = gameObject.GetComponentsInChildren<BoxCollider2D>();
        Invoke("EnableColliders", 1f);
    }

    // Update is called once per frame
    void EnableColliders()
    {
        foreach (var collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
