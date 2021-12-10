using System.Collections;
using UnityEngine;

public class Missile : Projectile
{
    public override GameObject SpawnParticlesPrefab { get; set; }
    public override GameObject DeathParticlesPrefab { get; set; }
    public override int Damage { get; set; }
    public override float MoveSpeed { get; set; }

    [SerializeField]
    private float _moveSpeed = 25f;

    private Transform _target;
    private bool _targetSet;

    public void SetTarget(Transform mountPoint, Transform target)
    {
        transform.position = mountPoint.position;
        _target = target;
        _targetSet = true;
    }

    private void Update()
    {
        if (_targetSet)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
        }
    }

    public IEnumerator SelfDestructAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(gameObject);
    }

    public override void Launch(Transform mountPoint)
    {
        throw new System.NotImplementedException();
    }
}