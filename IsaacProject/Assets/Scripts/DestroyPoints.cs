using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") || collision.CompareTag("ClosedRoom"))
        {
            Destroy(collision.gameObject);
        }
    }
}
