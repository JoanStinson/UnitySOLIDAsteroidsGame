using JGM.Game.Entities.Player;
using JGM.Game.Entities.Stats;
using JGM.Game.Utils;
using System.Collections;
using UnityEngine;

namespace JGM.Game.Entities.EnemyShip
{
    public class EnemyShip : LivingEntity
    {
        private const float _leftLimit = -9f;
        private bool _canMove = true;

        private void Update()
        {
            if (!_canMove)
            {
                return;
            }
            transform.position -= Vector3.right * MoveSpeed * Time.deltaTime;
            if (transform.position.x < _leftLimit)
            {
                StartCoroutine(ResetPosition());
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerHealth>(out var player))
            {
                SpawnDeathParticles();
                TakeDamage(player.Damage);
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (Health <= 0)
            {
                SpawnDeathParticles();
                StartCoroutine(ResetPosition());
            }
        }

        private IEnumerator ResetPosition()
        {
            gameObject.transform.position = RandomPositioner.GetRandomPos();
            _canMove = false;
            yield return new WaitForSeconds(Random.Range(0f, 4f));
            _canMove = true;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}