using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public float lifetime = 1;
    public float size;
    public Color color;
    
    private float creationTime;
    private Material mat;
    private void Start()
    {
        creationTime = Time.time;
        mat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        float progress = (Time.time - creationTime) / lifetime;
        
        color.a = 1 - progress;
        mat.color = color;

        transform.localScale += new Vector3(size, size, size) / lifetime * Time.deltaTime;

        if (progress >= 1)
        {
            Destroy(gameObject);
        }
    }
}
