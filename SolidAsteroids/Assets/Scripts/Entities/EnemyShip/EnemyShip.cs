using UnityEngine;

public class EnemyShip : LivingEntity
{
    private void Update()
    {
        transform.localPosition -= Vector3.right * MoveSpeed * Time.deltaTime;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (Health <= 0)
        {
            SpawnDeathParticles();
            Destroy(gameObject);
        }
    }
}