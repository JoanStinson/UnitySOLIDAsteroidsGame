using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerParticles : MonoBehaviour
{
    [SerializeField] private GameObject _deathParticlesPrefab;

    private void Awake()
    {
        GetComponent<PlayerHealth>().OnPlayerRespawn += SpawnDeathParticles;
    }

    private void SpawnDeathParticles()
    {
        Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
    }
}