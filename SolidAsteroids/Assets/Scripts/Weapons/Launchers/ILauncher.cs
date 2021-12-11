using UnityEngine;

public interface ILauncher
{
    ObjectPrefabPool<Transform> ProjectilesSpawnParticlesPool { get; }
    ObjectPrefabPool<Transform> ProjectilesDeathParticlesPool { get; }

    void Launch(Weapon weapon);
}