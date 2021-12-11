using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Projectile : MonoBehaviour, IProjectile, IMovingEntity
{
    public abstract int Damage { get; set; }
    public abstract float MoveSpeed { get; set; }

    protected ILauncher _launcher;
    protected bool _launched;

    public void SetLauncher(ILauncher launcher)
    {
        _launcher = launcher;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LivingEntity>(out var livingEntity))
        {
            SpawnDeathParticles();
            livingEntity.TakeDamage(Damage);
        }
    }

    public virtual void Launch(Transform mountPoint)
    {
        transform.position = mountPoint.position;
        _launcher.ProjectilesSpawnParticlesPool.Get(out var projectileSpawnParticle);
        projectileSpawnParticle.position = transform.position;
        projectileSpawnParticle.rotation = Quaternion.identity;
        _launched = true;
    }

    public virtual void SpawnDeathParticles()
    {
        _launcher.ProjectilesDeathParticlesPool.Get(out var projectileSpawnParticle);
        projectileSpawnParticle.position = transform.position;
        projectileSpawnParticle.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}