using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyShip : LivingEntity
{
    private void Update()
    {
        transform.position -= Vector3.right * MoveSpeed * Time.deltaTime;
        if (transform.position.x < -9f)
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
        await Task.Delay(TimeSpan.FromSeconds(2.5f));
        gameObject.SetActive(true);
        gameObject.transform.position = RandomPositioner.GetRandomPos();
    }
}