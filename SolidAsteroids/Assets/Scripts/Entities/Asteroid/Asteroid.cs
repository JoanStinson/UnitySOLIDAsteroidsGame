using System;
using UnityEngine;

public class Asteroid : LivingEntity
{
    public event Action OnAsteroidBreak = delegate { };

    [Header("Asteroid")]
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private float _frequency = 0.5f;
    [SerializeField] private float _magnitude = 4f;
    [SerializeField] private bool _shouldDestroy;

    private Vector3? _newPosition = null;
    private bool _startMovingUp;

    public void Initialize(bool startMovingUp, Vector3 startPosition)
    {
        _startMovingUp = startMovingUp;
        transform.position = startPosition;
        _newPosition = startPosition;
    }

    private void Start()
    {
        _newPosition = transform.position;
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, _rotationSpeed * Time.deltaTime);
        _newPosition -= Vector3.right * Time.deltaTime * MoveSpeed;
        if (_startMovingUp)
        {
            transform.position = (Vector3)(_newPosition + (Vector3.up * Mathf.Sin(_frequency * Time.time) * _magnitude));
        }
        else
        {
            transform.position = (Vector3)(_newPosition - (Vector3.up * Mathf.Sin(_frequency * Time.time) * _magnitude));
        }
        if (transform.position.x < -9f)
        {
            ResetPosition();
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (Health <= 0)
        {
            OnAsteroidBreak();
            SpawnDeathParticles();
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        if (_shouldDestroy)
        {
            Destroy(gameObject);
        }
        else
        {
            Initialize(false, RandomPositioner.GetRandomPos());
        }
    }
}