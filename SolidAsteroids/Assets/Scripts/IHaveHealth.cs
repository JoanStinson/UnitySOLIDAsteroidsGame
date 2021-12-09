public interface IHaveHealth
{
    int Health { get; }
    int MaxHealth { get; }

    void TakeDamage(int damage);
}
