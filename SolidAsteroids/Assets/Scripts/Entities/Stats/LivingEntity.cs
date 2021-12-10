using UnityEngine;

public abstract class LivingEntity : MonoBehaviour, IMovingEntity, IHaveHealth
{
    [field: Header("Living Entity")]
    [field: SerializeField] public float MoveSpeed { get; set; } = 0.1f;
    [field: SerializeField] public int Damage { get; set; } = 10;
    [field: SerializeField] public int MaxHealth { get; set; } = 100;
    [field: SerializeField] public GameObject DeathParticlesPrefab { get; set; }
    [field: Space(10)]

    public int Health { get; protected set; }

    protected virtual void Awake()
    {
        Health = MaxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
    }

    public virtual void SpawnDeathParticles()
    {
        Instantiate(DeathParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}