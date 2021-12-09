using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] public override GameObject DeathParticlesPrefab { get; }
    [SerializeField] public override int Damage { get; }
    [SerializeField] public override float MoveSpeed { get; }

    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private int _damageAmount = 10;

    private bool _launched;

    public override void Launch(Transform mountPoint)
    {
        transform.position = mountPoint.position;
        _launched = true;
    }

    private void Update()
    {
        if (_launched)
        {
            transform.position += Vector3.right * Time.deltaTime * _moveSpeed;
        }
    }
}