using UnityEngine;

public class EnemyShip : LivingEntity
{
    private void Update()
    {
        transform.position -= Vector3.right * MoveSpeed * Time.deltaTime;
        if (transform.position.x < -9f)
        {
            ReturnToPool();
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (Health <= 0)
        {
            SpawnDeathParticles();
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        //gameObject.transform.position = SpawnManager.GetRandomPos();
    }
}