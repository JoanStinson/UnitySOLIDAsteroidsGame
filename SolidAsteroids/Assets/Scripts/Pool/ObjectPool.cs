using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private readonly T[] _pool;

    public ObjectPool(int poolSize, GameObject prefab, string poolParentName = null)
    {
        _pool = new T[poolSize];
        if (string.IsNullOrEmpty(poolParentName))
        {
            poolParentName = $"{typeof(T)}sPool";
        }
        var poolParent = new GameObject(poolParentName);
        for (int i = 0; i < poolSize; ++i)
        {
            var pooledGO = GameObject.Instantiate(prefab);
            pooledGO.name = $"Pooled {typeof(T)} {i + 1}";
            pooledGO.transform.SetParent(poolParent.transform);
            pooledGO.SetActive(false);
            var pooledComponent = pooledGO.GetComponent<T>();
            _pool[i] = pooledComponent;
        }
    }

    public void Get(out T component)
    {
        component = null;
        for (int i = 0; i < _pool.Length; ++i)
        {
            if (!_pool[i].gameObject.activeSelf)
            {
                component = _pool[i];
                component.gameObject.SetActive(true);
                return;
            }
        }
    }
}