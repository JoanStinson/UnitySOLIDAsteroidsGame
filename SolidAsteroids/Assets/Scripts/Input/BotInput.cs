using System;
using Random = UnityEngine.Random;

public class BotInput : IInputService
{
    public float Vertical { get; private set; }
    public bool ShootProjectile { get; private set; }

    public void ReadInput()
    {
        Vertical = Random.Range(-1f, 1f);
        ShootProjectile = Convert.ToBoolean(Random.Range(0, 1));
    }
}