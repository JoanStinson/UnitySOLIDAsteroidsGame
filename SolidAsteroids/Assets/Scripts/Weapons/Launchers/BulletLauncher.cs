using JGM.Game.Weapons.Projectiles;
using JGM.Game.Pool;
using UnityEngine;

namespace JGM.Game.Weapons.Launchers
{
    public class BulletLauncher : MonoBehaviour, ILauncher
    {
        public ObjectPrefabPool<Transform> ProjectilesSpawnParticlesPool { get; private set; }
        public ObjectPrefabPool<Transform> ProjectilesDeathParticlesPool { get; private set; }

        [SerializeField] [Range(1, 50)] private int _bulletsPoolSize = 20;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _bulletSpawnParticlesPrefab;
        [SerializeField] private GameObject _bulletDeathParticlesPrefab;

        private ObjectPrefabPool<Bullet> _bulletsPool;

        private void Awake()
        {
            _bulletsPool = new ObjectPrefabPool<Bullet>(_bulletsPoolSize, _bulletPrefab);
            ProjectilesSpawnParticlesPool = new ObjectPrefabPool<Transform>(_bulletsPoolSize, _bulletSpawnParticlesPrefab, "BulletsSpawnParticlesPool");
            ProjectilesDeathParticlesPool = new ObjectPrefabPool<Transform>(_bulletsPoolSize, _bulletDeathParticlesPrefab, "BulletsDeathParticlesPool");
        }

        public void Launch(Weapon weapon)
        {
            _bulletsPool.Get(out var spawnedBullet);
            spawnedBullet?.SetLauncher(this);
            spawnedBullet?.Launch(weapon.WeaponMountPoint);
        }
    }
}