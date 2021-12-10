using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour, IProjectile, IMovingEntity
{
    public abstract GameObject DeathParticlesPrefab { get; }
    public abstract int Damage { get; }
    public abstract float MoveSpeed { get; }

    public abstract void Launch(Transform mountPoint);

    public virtual void SpawnDeathParticles()
    {
        Instantiate(DeathParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LivingEntity>(out var livingEntity))
        {
            livingEntity.TakeDamage(Damage);
        }
    }
}