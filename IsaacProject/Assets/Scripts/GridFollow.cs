using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform camTransform;
    private AstarPath grid;

    private void Start()
    {
        camTransform = GetComponentInParent<Transform>();
        grid = GetComponent<AstarPath>();
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, camTransform.position, 5f * Time.deltaTime);
    }
}
