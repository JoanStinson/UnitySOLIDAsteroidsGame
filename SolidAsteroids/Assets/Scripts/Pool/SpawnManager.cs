using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] [Range(3, 20)] private int _asteroidsPoolSize = 10;
    [SerializeField] private GameObject _asteroidPrefab;
    [Space(10)]
    [SerializeField] [Range(3, 20)] private int _enemyShipsPoolSize = 10;
    [SerializeField] private GameObject _enemyShipPrefab;

    //private PrefabObjectPool<Asteroid> _asteroidsPool;
    //private PrefabObjectPool<EnemyShip> _enemyShipsPool;

    private const float _bottomLimitSpawn = -3.85f;
    private const float _topLimitSpawn = 3.85f;
    private const float _leftLimitSpawn = 10f;
    private const float _rightLimitSpawn = 22f;

    //private void Awake()
    //{
    //    _asteroidsPool = new PrefabObjectPool<Asteroid>(_asteroidsPoolSize, _asteroidPrefab);
    //    _enemyShipsPool = new PrefabObjectPool<EnemyShip>(_enemyShipsPoolSize, _enemyShipPrefab);

    //    for (int i = 0; i < _asteroidsPool.Pool.Length; ++i)
    //    {
    //        float xRandomPos = Random.Range(_leftLimitSpawn, _rightLimitSpawn);
    //        float yRandomPos = Random.Range(_bottomLimitSpawn, _topLimitSpawn);
    //        _asteroidsPool.Pool[i].transform.position = new Vector2(xRandomPos, yRandomPos);
    //        _asteroidsPool.Pool[i].gameObject.SetActive(true);
    //    }

    //    for (int i = 0; i < _asteroidsPool.Pool.Length; ++i)
    //    {
    //        float xRandomPos = Random.Range(_leftLimitSpawn, _rightLimitSpawn);
    //        float yRandomPos = Random.Range(_bottomLimitSpawn, _topLimitSpawn);
    //        _enemyShipsPool.Pool[i].transform.position = new Vector2(xRandomPos, yRandomPos);
    //        _enemyShipsPool.Pool[i].gameObject.SetActive(true);
    //    }
    //}

    public static Vector2 GetRandomPos()
    {
        float xRandomPos = Random.Range(_leftLimitSpawn, _rightLimitSpawn);
        float yRandomPos = Random.Range(_bottomLimitSpawn, _topLimitSpawn);
        return new Vector2(xRandomPos, yRandomPos);
    }
}