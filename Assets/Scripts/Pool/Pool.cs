using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Pool<T> : MonoBehaviour where T : PoolableObject<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolMaxSize;

    private List<T> _createdObjects;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _createdObjects = new List<T>();

        _pool = new ObjectPool<T>(
            createFunc: () => CreateObject(),
            actionOnGet: t => t.gameObject.SetActive(true),
            actionOnRelease: t => t.gameObject.SetActive(false),
            actionOnDestroy: t => Destroy(t.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolMaxSize,
            maxSize: _poolMaxSize);
    }

    public T GetObjects() => _pool.Get();

    public void ReleaseObjects(T t)
    {
        _pool.Release(t);
    }

    public void Clear()
    {
        foreach (T t in _createdObjects)
        {
            Destroy(t.gameObject);
        }

        _pool.Clear();
        _createdObjects.Clear();
    }

    private T CreateObject()
    {
        T poolableObject = Instantiate(_prefab);
        _createdObjects.Add(poolableObject);

        return poolableObject;
    }
}
