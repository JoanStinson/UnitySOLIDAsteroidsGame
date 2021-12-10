using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    public abstract int Damage { get; }

    [SerializeField]
    protected int _maxHealth = 100;

    protected int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
    }
}