using UnityEngine;

public class Asteroid : LivingEntity
{
    [Header("Asteroid")]
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private float _frequency = 0.5f;
    [SerializeField] private float _magnitude = 4f;

    private Vector3 _newPosition;
    private bool _startMovingUp;

    public void SetStartDirection(bool startMovingUp)
    {
        _startMovingUp = startMovingUp;
    }

    protected override void Awake()
    {
        base.Awake();
        _newPosition = transform.position;
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, _rotationSpeed * Time.deltaTime);
        _newPosition -= Vector3.right * Time.deltaTime * MoveSpeed;
        if (_startMovingUp)
        {
            transform.position = _newPosition + (Vector3.up * Mathf.Sin(_frequency * Time.time) * _magnitude);
        }
        else
        {
            transform.position = _newPosition - (Vector3.up * Mathf.Sin(_frequency * Time.time) * _magnitude);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (Health <= 0)
        {
            SpawnDeathParticles();
            //var spawnedAsteroidPiece = Instantiate(_asteroidPiecePrefab);
            //spawnedAsteroidPiece.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}