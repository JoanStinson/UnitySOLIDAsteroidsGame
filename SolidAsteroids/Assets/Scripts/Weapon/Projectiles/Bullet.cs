using UnityEngine;

public class Bullet : Projectile
{
    [field: SerializeField] public override GameObject SpawnParticlesPrefab { get; set; }
    [field: SerializeField] public override GameObject DeathParticlesPrefab { get; set; }
    [field: SerializeField] public override int Damage { get; set; } = 10;
    [field: SerializeField] public override float MoveSpeed { get; set; } = 25f;

    private bool _launched;

    public override void Launch(Transform mountPoint)
    {
        transform.position = mountPoint.position;
        _launched = true;
        base.Launch(mountPoint);
    }

    private void Update()
    {
        if (_launched)
        {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
    }
}