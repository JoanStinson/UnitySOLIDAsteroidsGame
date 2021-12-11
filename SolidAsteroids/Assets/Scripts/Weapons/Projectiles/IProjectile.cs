using UnityEngine;

namespace JGM.Game.Weapons.Projectiles
{
    public interface IProjectile
    {
        void Launch(Transform mountPoint);
    }
}