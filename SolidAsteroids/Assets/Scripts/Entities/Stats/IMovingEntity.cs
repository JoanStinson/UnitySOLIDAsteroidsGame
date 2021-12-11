public interface IMovingEntity
{
    float MoveSpeed { get; }
    int Damage { get; }

    void SpawnDeathParticles();
}