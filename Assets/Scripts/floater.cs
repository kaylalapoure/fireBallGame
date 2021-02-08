using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floater : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0.001f, 0) * Mathf.Sin(Time.time));
    }
}
