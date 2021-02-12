using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private float _offsetTime = 0f;
    [SerializeField] GameObject _FireBall;

    private void Start()
    {   
        _offsetTime = Random.Range(0f, 6.28f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, 0.002f, 0f) * Mathf.Sin(Time.time+_offsetTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player Throwable"))
            _FireBall.SetActive(true);
    }
}
