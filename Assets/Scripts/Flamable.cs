using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamable : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _flameDuration = 5f;
    [SerializeField] private bool _destroyAtEnd = false;
    
    private ParticleSystem.ShapeModule _psShape;
    private GameObject _instance;

    private void SetOnFire()
    {
        _instance = Instantiate(_particlePrefab);
        // _instance.transform.position = transform.position;
        _instance.transform.SetParent(transform);
        _psShape = _instance.GetComponentInChildren<ParticleSystem.ShapeModule>();
        _psShape.mesh = GetComponent<MeshFilter>().mesh;
        StartCoroutine(BurnForTime());
    }

    private IEnumerator BurnForTime()
    {
        yield return new  WaitForSeconds(_flameDuration);
        if (_destroyAtEnd)
            Destroy(gameObject);
        else
            Destroy(_instance);
    }
}
