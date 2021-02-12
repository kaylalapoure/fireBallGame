using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floater : MonoBehaviour
{
    private float _offsetTime = 0f;
    private void Start()
    {   
        _offsetTime = Random.Range(0f, 6.28f);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0f, 0.002f, 0f) * Mathf.Sin(Time.time+_offsetTime));
    }
}
