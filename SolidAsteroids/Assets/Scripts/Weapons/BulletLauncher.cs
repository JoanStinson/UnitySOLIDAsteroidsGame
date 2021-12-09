using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] 
    private Bullet _bulletPrefab;

    public void Launch(Weapon weapon)
    {
        var spawnedBullet = Instantiate(_bulletPrefab);
        spawnedBullet.Launch(weapon.WeaponMountPoint);
    }
}