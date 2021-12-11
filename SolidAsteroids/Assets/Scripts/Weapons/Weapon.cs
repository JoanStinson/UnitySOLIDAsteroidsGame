using JGM.Game.Entities.Player;
using JGM.Game.Weapons.Launchers;
using UnityEngine;

namespace JGM.Game.Weapons
{
    [RequireComponent(typeof(ILauncher))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PlayerInput))]
    public class Weapon : MonoBehaviour
    {
        public Transform WeaponMountPoint => _weaponMountPoint;

        [SerializeField] private float _fireWeaponRefreshRate = 0.25f;
        [SerializeField] private Transform _weaponMountPoint;

        private ILauncher _launcher;
        private AudioSource _audioSource;
        private float _nextFireTime;

        private void Awake()
        {
            _launcher = GetComponent<ILauncher>();
            _audioSource = GetComponent<AudioSource>();
            GetComponent<PlayerInput>().OnFireWeapon += FireWeapon;
        }

        private void FireWeapon()
        {
            if (!CanFire())
            {
                return;
            }

            _nextFireTime = Time.time + _fireWeaponRefreshRate;
            _audioSource.Play();
            _launcher?.Launch(this);
        }

        private bool CanFire()
        {
            return Time.time >= _nextFireTime;
        }
    }
}