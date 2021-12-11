using JGM.Game.Entities.Stats;
using JGM.Game.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace JGM.Game.Entities.EnemyShip
{
    public class EnemyShip : LivingEntity
    {
        private const float _leftLimit = -9f;
        private const float _resetDelayInSeconds = 2.5f;
        private CancellationTokenSource _tokenSource;

        private void Awake()
        {
            _tokenSource = new CancellationTokenSource();
        }

        private void Update()
        {
            transform.position -= Vector3.right * MoveSpeed * Time.deltaTime;

            if (transform.position.x < _leftLimit)
            {
                ResetPosition();
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (Health <= 0)
            {
                SpawnDeathParticles();
                ResetPosition();
            }
        }

        private async void ResetPosition()
        {
            gameObject.SetActive(false);
            await Task.Delay(TimeSpan.FromSeconds(_resetDelayInSeconds), _tokenSource.Token);
            gameObject.SetActive(true);
            gameObject.transform.position = RandomPositioner.GetRandomPos();
        }

        private void OnDestroy()
        {
            _tokenSource.Cancel();
        }
    }
}