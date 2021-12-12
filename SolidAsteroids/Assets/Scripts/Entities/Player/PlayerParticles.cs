using UnityEngine;

namespace JGM.Game.Entities.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerParticles : MonoBehaviour
    {
        private GameObject _deathParticlesPrefab;

        private void Awake()
        {
            var playerHealth = GetComponent<PlayerHealth>();
            playerHealth.OnPlayerRespawn += SpawnDeathParticles;
            _deathParticlesPrefab = playerHealth.DeathParticlesPrefab;
        }

        private void SpawnDeathParticles()
        {
            Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
        }
    }
}