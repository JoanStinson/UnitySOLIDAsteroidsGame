using System.Collections;
using UnityEngine;

namespace JGM.Game.Weapons.Projectiles
{
    public class Missile : Projectile
    {
        [field: SerializeField] public override int Damage { get; set; } = 20;
        [field: SerializeField] public override float MoveSpeed { get; set; } = 15f;

        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            if (_launched && _target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, MoveSpeed * Time.deltaTime);

                if (transform.position.x > 9f)
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public IEnumerator SelfDestructAfterDelay(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            gameObject.SetActive(false);
        }
    }
}