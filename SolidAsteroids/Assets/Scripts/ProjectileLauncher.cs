using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _projectileSpawnPoint;

    private void Awake()
    {
        GetComponent<PlayerInput>().OnShootProjectile += SpawnProjectile;
    }

    private void SpawnProjectile()
    {
        var spawnedProjectile = Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        spawnedProjectile.transform.position = transform.position;
    }
}