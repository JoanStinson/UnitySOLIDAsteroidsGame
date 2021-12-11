using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher
{
    public ObjectPool<Transform> ProjectilesSpawnParticlesPool { get; private set; }
    public ObjectPool<Transform> ProjectilesDeathParticlesPool { get; private set; }

    [SerializeField] [Range(1, 50)] private int _bulletsPoolSize = 20;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletSpawnParticlesPrefab;
    [SerializeField] private GameObject _bulletDeathParticlesPrefab;

    private ObjectPool<Bullet> _bulletsPool;

    private void Awake()
    {
        _bulletsPool = new ObjectPool<Bullet>(_bulletsPoolSize, _bulletPrefab);
        ProjectilesSpawnParticlesPool = new ObjectPool<Transform>(_bulletsPoolSize, _bulletSpawnParticlesPrefab, "BulletsSpawnParticlesPool");
        ProjectilesDeathParticlesPool = new ObjectPool<Transform>(_bulletsPoolSize, _bulletDeathParticlesPrefab, "BulletsDeathParticlesPool");
    }

    public void Launch(Weapon weapon)
    {
        _bulletsPool.Get(out var spawnedBullet);
        spawnedBullet?.SetLauncher(this);
        spawnedBullet?.Launch(weapon.WeaponMountPoint);
    }
}