public interface IHaveHealth
{
    int MaxHealth { get; }
    int Health { get; }

    void TakeDamage(int damage);
}