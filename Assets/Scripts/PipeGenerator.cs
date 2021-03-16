using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _maxHeigth;
    [SerializeField] private float _minHeigth;

    private void Awake()
    {
        Initialize(_prefab);
        StartCoroutine(Generating());
    }

    private void GeneratePipe(GameObject pipe)
    {
        float heigth = Random.Range(_minHeigth, _maxHeigth);
        Vector3 position = new Vector3(transform.position.x, heigth, transform.position.z);
        pipe.SetActive(true);
        pipe.transform.position = position;
    }

    private IEnumerator Generating()
    {
        var wait = new WaitForSeconds(_spawnInterval);
        while (enabled)
        {
            if (TryGetObject(out GameObject pipe))
            {
                GeneratePipe(pipe);
                DisabledObjects();
                yield return wait;
            }
            yield return null;
        }
    }
}
