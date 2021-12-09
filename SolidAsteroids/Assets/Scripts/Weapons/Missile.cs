using System.Collections;
using UnityEngine;

public class Missile : Projectile
{
    public override int Damage => 15;

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
}