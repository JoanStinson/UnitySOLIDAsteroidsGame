using System;
using UnityEngine;

[RequireComponent(typeof(UserInput))]
public class PlayerInput : MonoBehaviour
{
    public IInputService Input { get; private set; }
    public event Action OnFireWeapon = delegate { };

    [SerializeField]
    private PlayerSettings _playerSettings;

    private void Awake()
    {
        Input = _playerSettings.UseBot ? new BotInput() as IInputService: new UserInput();
    }

    private void Update()
    {
        Input.ReadInput();

        if (Input.ShootProjectile)
        {
            OnFireWeapon();
        }
    }
}