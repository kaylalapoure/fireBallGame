using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float radius;
    public float speed;
    
    private float degreesPerPickup;
    
    // Start is called before the first frame update
    void Start()
    {
        degreesPerPickup = 360f / transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            float separation = Time.time * speed + degreesPerPickup * child.transform.GetSiblingIndex() * Mathf.Deg2Rad;
            float x = radius * Mathf.Sin(separation);
            float z = radius * Mathf.Cos(separation);
            child.transform.position = new Vector3(x, child.transform.position.y, z) + transform.position;
        }
    }
}
