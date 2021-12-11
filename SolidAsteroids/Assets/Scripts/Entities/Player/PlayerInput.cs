using JGM.Game.Input;
using JGM.Game.Settings;
using System;
using UnityEngine;

namespace JGM.Game.Entities.Player
{
    [RequireComponent(typeof(UserInput))]
    public class PlayerInput : MonoBehaviour
    {
        public IInputService Input { get; private set; }
        public event Action OnFireWeapon = delegate { };

        [SerializeField]
        private PlayerSettings _playerSettings;

        private void Awake()
        {
            Input = _playerSettings.UseBot ? new BotInput() as IInputService : new UserInput();
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
}