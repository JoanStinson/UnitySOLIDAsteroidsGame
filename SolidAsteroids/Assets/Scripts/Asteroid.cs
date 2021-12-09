using UnityEngine;

public class Asteroid : LivingEntity
{
    public override int Damage => 100;

    [SerializeField] private float _moveSpeed = 0.1f;
    [SerializeField] private float rotationSpeed = 30f;
    [SerializeField] private float _frequency = 0.5f;
    [SerializeField] private float _magnitude = 4f;

    private Vector3 _newPosition;

    private void Start()
    {
        _newPosition = transform.position;
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
        _newPosition -= Vector3.right * Time.deltaTime * _moveSpeed;
        transform.position = _newPosition + Vector3.up * Mathf.Sin(_frequency * Time.time) * _magnitude;
    }

    //public override void TakeDamage(int damage)
    //{
    //    base.TakeDamage(damage);
    //    if (_health <= 0)
    //    {
    //        var spawnedAsteroidPiece = Instantiate(_asteroidPiecePrefab);
    //        spawnedAsteroidPiece.transform.position = Transform.position;
    //        Destroy(gameObject);
    //    }
    //}
}