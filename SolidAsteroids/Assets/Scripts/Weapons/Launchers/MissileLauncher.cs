using UnityEngine;

public class MissileLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] private Missile _missilePrefab;
    [SerializeField] private float _missileSelfDestructTimer = 5f;

    public void Launch(Weapon weapon)
    {
        var target = FindObjectOfType<Asteroid>();
        var spawnedMissile = Instantiate(_missilePrefab);
        spawnedMissile.SetTarget(target.transform);
        spawnedMissile.Launch(weapon.WeaponMountPoint);
        StartCoroutine(spawnedMissile.SelfDestructAfterDelay(_missileSelfDestructTimer));
    }
}