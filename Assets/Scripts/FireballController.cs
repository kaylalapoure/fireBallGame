using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;

    private Rigidbody _rb;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        // other.gameObject.SendMessageUpwards("SetOnFire");
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        Explode(other.gameObject);
    }
    
    private void Explode(GameObject other)
    {
        // gameObject.GetComponentsInChildren<ParticleSystem>();
        var obj = Instantiate(explosionPrefab);
        obj.transform.position = transform.position;
        obj.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}