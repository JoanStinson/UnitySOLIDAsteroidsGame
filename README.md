# Solid Asteroids
A mini space game made applying all SOLID Principles to serve as a reference of good code architecture.

## 🧊 Single Responsibility Principle
A class should have only one responsibility.

### ❌ Wrong Way
```csharp
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private bool _isInvulnerable;
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _movingUpSprite;
    [SerializeField] private Sprite _movingDownSprite;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject _deathParticlesPrefab;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _initialPosition;
    private const float _timeToRespawn = 2f;
    private int _health;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initialPosition = transform.position;
        _health = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            ShootProjectile();
        }

        var vertical = Input.GetAxis("Vertical");
        transform.position += Vector3.up * vertical * _moveSpeed * Time.deltaTime;
        if (vertical == 0)
        {
            _spriteRenderer.sprite = _idleSprite;
        }
        else
        {
            _spriteRenderer.sprite = vertical > 0 ? _movingUpSprite : _movingDownSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Asteroid>(out var asteroid))
        {
            TakeDamage(asteroid.Damage);
        }
        else if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            TakeDamage(enemy.Damage);
        }
    }

    private void ShootProjectile()
    {
        var spawnedProjectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        spawnedProjectile.transform.position = transform.position;
    }

    private void TakeDamage(int damage)
    {
        if (!_isInvulnerable)
        {
            _health -= damage;
            if (_health <= 0)
            {
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn()
    {
        _isInvulnerable = true;
        _spriteRenderer.enabled = false;
        Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(_timeToRespawn);
        transform.position = _initialPosition;
        _spriteRenderer.enabled = true;
        _isInvulnerable = false;
    }
```
### ✔️ Right Way
```csharp
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerDrawer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _movingUpSprite;
    [SerializeField] private Sprite _movingDownSprite;

    private PlayerInput _playerInput;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _initialPosition;
    private const float _timeToMakePlayerVisibleAgain = 2f;

    private void Awake()
    {
        GetComponent<PlayerHealth>().OnPlayerRespawn += RespawnPlayer;
        _playerInput = GetComponent<PlayerInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position += Vector3.up * _playerInput.Vertical * _moveSpeed * Time.deltaTime;

        if (_playerInput.Vertical == 0)
        {
            _spriteRenderer.sprite = _idleSprite;
        }
        else
        {
            _spriteRenderer.sprite = _playerInput.Vertical > 0 ? _movingUpSprite : _movingDownSprite;
        }
    }

    private void RespawnPlayer()
    {
        StartCoroutine(Respawn(_timeToMakePlayerVisibleAgain));
    }

    private IEnumerator Respawn(float delayInSeconds)
    {
        _spriteRenderer.enabled = false;
        yield return new WaitForSeconds(delayInSeconds);
        transform.position = _initialPosition;
        _spriteRenderer.enabled = true;
    }
}
```
```csharp
public class PlayerInput : MonoBehaviour
{
    public float Vertical { get; private set; }
    public bool ShootProjectile { get; private set; }

    public event Action OnShootProjectile = delegate { };

    private void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        ShootProjectile = Input.GetButtonDown("Submit");
        if (ShootProjectile)
        {
            OnShootProjectile();
        }
    }
}
```
```csharp
[RequireComponent(typeof(Collider2D))]
public class PlayerHealth : MonoBehaviour
{
    public event Action OnPlayerRespawn = delegate { };

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private bool _isInvulnerable;

    private const float _delayToDisableInvulnerability = 3f;
    private int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Asteroid>(out var asteroid))
        {
            TakeDamage(asteroid.Damage);
        }
        else if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            TakeDamage(enemy.Damage);
        }
    }

    private void TakeDamage(int damage)
    {
        if (!_isInvulnerable)
        {
            _health -= damage;
            if (_health <= 0)
            {
                RespawnPlayer();
            }
        }
    }

    private void RespawnPlayer()
    {
        _isInvulnerable = true;
        OnPlayerRespawn();
        StartCoroutine(DisableInvulnerability(_delayToDisableInvulnerability));
    }

    private IEnumerator DisableInvulnerability(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        _isInvulnerable = false;
    }
}
```
```csharp
[RequireComponent(typeof(PlayerHealth))]
public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private GameObject _deathParticlesPrefab;

    private void Awake()
    {
        GetComponent<PlayerHealth>().OnPlayerRespawn += SpawnDeathParticles;
    }

    private void SpawnDeathParticles()
    {
        Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
    }
}
```
```csharp
[RequireComponent(typeof(PlayerInput))]
public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;

    private void Awake()
    {
        GetComponent<PlayerInput>().OnShootProjectile += SpawnProjectile;
    }

    private void SpawnProjectile()
    {
        var spawnedProjectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        spawnedProjectile.transform.position = transform.position;
    }
}
```

## 🚪 Open-Closed Principle
A software module (it can be a class or method) should be open for extension but closed for modification.

### ❌ Wrong Way

### ✔️ Right Way

## 🦆 Liskov Substitution Principle
Derived classes must be substitutable for their base classes.

### ❌ Wrong Way

### ✔️ Right Way

## 🤼 Interface Segregation Principle
Clients should not be forced to depend upon the interfaces that they do not use.

### ❌ Wrong Way

### ✔️ Right Way

## ↕️ Dependency Inversion Principle
Program to an interface, not to an implementation.

### ❌ Wrong Way

### ✔️ Right Way
