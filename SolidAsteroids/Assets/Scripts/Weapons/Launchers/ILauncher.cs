using JGM.Game.Weapons;
using JGM.Game.Pool;
using UnityEngine;

namespace JGM.Game.Weapons.Launchers
{
    public interface ILauncher
    {
        ObjectPrefabPool<Transform> ProjectilesSpawnParticlesPool { get; }
        ObjectPrefabPool<Transform> ProjectilesDeathParticlesPool { get; }

        void Launch(Weapon weapon);
    }
}