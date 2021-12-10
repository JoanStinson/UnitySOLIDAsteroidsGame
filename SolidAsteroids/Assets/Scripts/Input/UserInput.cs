using UnityEngine;

public class UserInput : IInputService
{
    public float Vertical { get; private set; }
    public bool ShootProjectile { get; private set; }

    public void ReadInput()
    {
        Vertical = Input.GetAxis("Vertical");
        ShootProjectile = Input.GetButtonDown("Submit");
    }
}