using UnityEngine;

public interface ILauncher
{
    ObjectPool<Transform> ProjectilesSpawnParticlesPool { get; }
    ObjectPool<Transform> ProjectilesDeathParticlesPool { get; }

    void Launch(Weapon weapon);
}