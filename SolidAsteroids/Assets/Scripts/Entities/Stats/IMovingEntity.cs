using UnityEngine;

public interface IMovingEntity
{
    //GameObject DeathParticlesPrefab { get; }
    float MoveSpeed { get; }
    int Damage { get; }

    void SpawnDeathParticles();
}