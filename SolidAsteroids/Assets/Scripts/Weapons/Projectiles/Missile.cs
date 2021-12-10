using System.Collections;
using UnityEngine;

public class Missile : Projectile
{
    [field: SerializeField] public override GameObject SpawnParticlesPrefab { get; set; }
    [field: SerializeField] public override GameObject DeathParticlesPrefab { get; set; }
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
        }
    }

    public IEnumerator SelfDestructAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(gameObject);
    }
}