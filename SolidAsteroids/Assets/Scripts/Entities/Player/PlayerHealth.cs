using JGM.Game.Entities.Stats;
using System;
using System.Collections;
using UnityEngine;

namespace JGM.Game.Entities.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerHealth : LivingEntity
    {
        public event Action OnPlayerRespawn = delegate { };

        [Header("Player")]
        [SerializeField]
        private bool _isInvulnerable;

        private const float _delayToDisableInvulnerability = 3f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<LivingEntity>(out var livingEntity))
            {
                TakeDamage(livingEntity.Damage);
            }
        }

        public override void TakeDamage(int damage)
        {
            if (!_isInvulnerable)
            {
                Health -= damage;
                if (Health <= 0)
                {
                    RespawnPlayer();
                }
            }
        }

        private void RespawnPlayer()
        {
            _isInvulnerable = true;
            OnPlayerRespawn();
            StartCoroutine(DisableInvulnerability(_delayToDisableInvulnerability));
        }

        private IEnumerator DisableInvulnerability(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            _isInvulnerable = false;
        }
    }
}