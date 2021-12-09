using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerHealth : LivingEntity
{
    public override int Damage => 10;
    public event Action OnPlayerRespawn = delegate { };

    [SerializeField] 
    private bool _isInvulnerable;

    private const float _delayToDisableInvulnerability = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<LivingEntity>(out var livingEntity))
        {
            TakeDamage(livingEntity.Damage);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (!_isInvulnerable)
        {
            _health -= damage;
            if (_health <= 0)
            {
                RespawnPlayer();
            }
        }
    }

    private void RespawnPlayer()
    {
        _isInvulnerable = true;
        OnPlayerRespawn();
        StartCoroutine(DisableInvulnerability(_delayToDisableInvulnerability));
    }

    private IEnumerator DisableInvulnerability(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        _isInvulnerable = false;
    }
}