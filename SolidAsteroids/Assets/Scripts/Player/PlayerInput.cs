using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Vertical { get; private set; }
    public bool ShootProjectile { get; private set; }

    public event Action OnFireWeapon = delegate { };

    private void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        ShootProjectile = Input.GetButtonDown("Submit");
        if (ShootProjectile)
        {
            OnFireWeapon();
        }
    }
}