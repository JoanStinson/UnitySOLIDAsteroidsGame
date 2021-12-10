using UnityEngine;

public class Enemy : LivingEntity
{
    public override int Damage => 100;

    [SerializeField] 
    private float _moveSpeed = 2f;

    private void Update()
    {
        transform.localPosition -= Vector3.right * Time.deltaTime * _moveSpeed;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}