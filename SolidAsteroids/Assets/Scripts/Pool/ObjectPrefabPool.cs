using UnityEngine;

public class ObjectPrefabPool<T> where T : Component
{
    private readonly T[] _pool;

    public ObjectPrefabPool(int poolSize, GameObject objectPrefab, string poolParentName = null)
    {
        _pool = new T[poolSize];
        if (string.IsNullOrEmpty(poolParentName))
        {
            poolParentName = $"{typeof(T)}sPool";
        }
        var poolParent = new GameObject(poolParentName);
        for (int i = 0; i < poolSize; ++i)
        {
            var pooledGO = GameObject.Instantiate(objectPrefab);
            pooledGO.name = $"Pooled {typeof(T)} {i + 1}";
            pooledGO.transform.SetParent(poolParent.transform);
            pooledGO.SetActive(false);
            var pooledComponent = pooledGO.GetComponent<T>();
            _pool[i] = pooledComponent;
        }
    }

    public void Get(out T pooledObject)
    {
        pooledObject = null;
        for (int i = 0; i < _pool.Length; ++i)
        {
            if (!_pool[i].gameObject.activeSelf)
            {
                pooledObject = _pool[i];
                pooledObject.gameObject.SetActive(true);
                return;
            }
        }
    }
}