using JGM.Game.Weapons;
using JGM.Game.Weapons.Projectiles;
using JGM.Game.Entities.Asteroid;
using JGM.Game.Pool;
using UnityEngine;

namespace JGM.Game.Weapons.Launchers
{
    public class MissileLauncher : MonoBehaviour, ILauncher
    {
        public ObjectPrefabPool<Transform> ProjectilesSpawnParticlesPool { get; private set; }
        public ObjectPrefabPool<Transform> ProjectilesDeathParticlesPool { get; private set; }

        [SerializeField] [Range(1, 50)] private int _missilesPoolSize = 20;
        [SerializeField] private GameObject _missilePrefab;
        [SerializeField] private GameObject _missileSpawnParticlesPrefab;
        [SerializeField] private GameObject _missileDeathParticlesPrefab;
        [SerializeField] private float _missileSelfDestructTimer = 5f;

        private ObjectPrefabPool<Missile> _missilesPool;

        private void Awake()
        {
            _missilesPool = new ObjectPrefabPool<Missile>(_missilesPoolSize, _missilePrefab);
            ProjectilesSpawnParticlesPool = new ObjectPrefabPool<Transform>(_missilesPoolSize, _missileSpawnParticlesPrefab, "MissileSpawnParticlesPool");
            ProjectilesDeathParticlesPool = new ObjectPrefabPool<Transform>(_missilesPoolSize, _missileDeathParticlesPrefab, "MissileDeathParticlesPool");
        }

        public void Launch(Weapon weapon)
        {
            var target = FindObjectOfType<Asteroid>();
            _missilesPool.Get(out var spawnedMissile);
            spawnedMissile?.SetLauncher(this);
            spawnedMissile?.SetTarget(target.transform);
            spawnedMissile?.Launch(weapon.WeaponMountPoint);
            StartCoroutine(spawnedMissile?.SelfDestructAfterDelay(_missileSelfDestructTimer));
        }
    }
}