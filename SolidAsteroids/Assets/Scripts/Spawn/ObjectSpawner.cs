using System;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] [Range(1, 20)] private int _maxSpawn = 5;
    [SerializeField] [Range(0f, 5f)] private float _delayBetweenSpawnsInSeconds = 0.5f;
    [SerializeField] private GameObject _objectPrefab;

    private GameObject[] _objects;

    private async void Awake()
    {
        var spawnParent = new GameObject($"{_objectPrefab.name}Spawns");
        _objects = new GameObject[_maxSpawn];
        for (int i = 0; i < _maxSpawn; ++i)
        {
            var spawnedObject = Instantiate(_objectPrefab);
            spawnedObject.transform.SetParent(spawnParent.transform);
            spawnedObject.transform.position = RandomPositioner.GetRandomPos();
            _objects[i] = spawnedObject;
            await Task.Delay(TimeSpan.FromSeconds(_delayBetweenSpawnsInSeconds));
        }
    }
}