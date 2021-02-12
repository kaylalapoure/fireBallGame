using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    private Rigidbody _rb;
    private Valve.VR.InteractionSystem.VRController _vrController;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _vrController = GameObject.Find("Player").GetComponent<Valve.VR.InteractionSystem.VRController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.SendMessageUpwards("SetOnFire");
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
        if (other.gameObject.CompareTag("Pick Up"))
            _vrController.IncrementCount();
        Explode(other.gameObject);
    }
    
    private void Explode(GameObject other)
    {
        var obj = Instantiate(explosionPrefab);
        obj.transform.position = transform.position;
        obj.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(gameObject);
    }

    // Destroy if it falls out of the world 
    private void LateUpdate()
    {
        if(transform.position.y < -50f)
            Destroy(gameObject);
    }
}