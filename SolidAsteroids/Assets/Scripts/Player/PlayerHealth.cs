using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerHealth : MonoBehaviour
{
    public event Action OnPlayerRespawn = delegate { };

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private bool _isInvulnerable;

    private const float _delayToDisableInvulnerability = 3f;
    private int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Asteroid>(out var asteroid))
        {
            TakeDamage(asteroid.Damage);
        }
        else if (collision.collider.TryGetComponent<Enemy>(out var enemy))
        {
            TakeDamage(enemy.Damage);
        }
    }

    private void TakeDamage(int damage)
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