using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerHealth : LivingEntity
{
    public event Action OnPlayerRespawn = delegate { };

    [Header("Player")]
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
            Health -= damage;
            if (Health <= 0)
            {
                //SpawnDeathParticles();
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