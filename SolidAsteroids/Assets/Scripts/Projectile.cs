using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : LivingEntity
{
    public abstract override int Damage { get; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LivingEntity>(out var livingEntity))
        {
            livingEntity.TakeDamage(Damage);
        }
    }
}