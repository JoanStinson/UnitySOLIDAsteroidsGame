using UnityEngine;

public class MissileLauncher : MonoBehaviour, ILauncher
{
    public ObjectPool<Transform> ProjectilesSpawnParticlesPool { get; private set; }
    public ObjectPool<Transform> ProjectilesDeathParticlesPool { get; private set; }

    [SerializeField] [Range(1, 50)] private int _missilesPoolSize = 20;
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private GameObject _missileSpawnParticlesPrefab;
    [SerializeField] private GameObject _missileDeathParticlesPrefab;
    [SerializeField] private float _missileSelfDestructTimer = 5f;

    private ObjectPool<Missile> _missilesPool;

    private void Awake()
    {
        _missilesPool = new ObjectPool<Missile>(_missilesPoolSize, _missilePrefab);
        ProjectilesSpawnParticlesPool = new ObjectPool<Transform>(_missilesPoolSize, _missileSpawnParticlesPrefab, "MissileSpawnParticlesPool");
        ProjectilesDeathParticlesPool = new ObjectPool<Transform>(_missilesPoolSize, _missileDeathParticlesPrefab, "MissileDeathParticlesPool");
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