using UnityEngine;

public class Bullet : Projectile
{
    public override int Damage => 10;

    [SerializeField] private float _moveSpeed = 25f;
    [SerializeField] private int _damageAmount = 10;

    private bool _launched;

    public void Launch(Transform mountPoint)
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