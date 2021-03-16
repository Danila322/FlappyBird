using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    private Camera _camera;
    private GameObject[] _pool;

    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;
        _pool = new GameObject[_capacity];
        for (int i = 0; i < _pool.Length; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool[i] = spawned;
        }
    }

    protected bool TryGetObject(out GameObject @object)
    {
        @object = _pool.FirstOrDefault(o => !o.activeSelf);
        return @object != null;
    }

    protected void DisabledObjects()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(Vector3.zero);

        foreach (var item in _pool)
        {
            if(item.transform.position.x < disablePoint.x)
            {
                item.SetActive(false);
            }
        }
    }

    public void ResetPool()
    {
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i].SetActive(false);
        }
    }
}
