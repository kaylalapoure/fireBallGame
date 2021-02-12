using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamable : MonoBehaviour
{
    [SerializeField] private GameObject _particlePrefab;
    [SerializeField] private float _flameDuration = 30f;
    [SerializeField] private bool _destroyAtEnd = false;
    
    private ParticleSystem _ps;
    private GameObject _instance;

    private void SetOnFire()
    {
        _instance = Instantiate(_particlePrefab);
        _instance.transform.SetParent(transform);
        var bounds = GetComponent<MeshFilter>().sharedMesh.bounds;
        _instance.transform.localPosition = new Vector3(0f, bounds.center.y, 0f);
        GetComponentInChildren<Light>().intensity = 1f;
        _ps = _instance.GetComponentInChildren<ParticleSystem>();
        var shape = _ps.shape;
        shape.meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(BurnForTime());
    }

    private IEnumerator BurnForTime()
    {
        _ps.Play();
        yield return new WaitForSeconds(_flameDuration);
        if (_destroyAtEnd)
            Destroy(gameObject);
        else
            Destroy(_instance);
    }
}
