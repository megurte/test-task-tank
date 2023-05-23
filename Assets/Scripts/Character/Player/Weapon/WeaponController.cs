using System;
using System.Collections.Generic;
using Constants;
using Factories;
using Interfaces;
using ScriptableObjects;
using Services;
using UnityEngine;
using Zenject;

namespace Character.Player.Weapon
{
    [RequireComponent(typeof(PlayerMovement))]
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private WeaponAbstract weaponComponent;

        private PlayerMovement _playerMovement;
        private List<PlayerWeaponSettings> _weaponArmory = new List<PlayerWeaponSettings>();
        private IInputService _inputService;
        private BulletFactory _bulletFactory;
        private int _currentWeaponIndex = default;
        private Vector2 _facingDirection = ValueConstants._defaultFacingDirection;

        [Inject]
        public void SetDependency(IInputService inputService, BulletFactory bulletFactory, PlayerUnitSettings playerUnitSettings)
        {
            _weaponArmory = playerUnitSettings.AvailableWeapons;
            _inputService = inputService;
            _bulletFactory = bulletFactory;
        }

        private void Start()
        {
            SetWeapon(_currentWeaponIndex);
        }

        private void OnEnable()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.FacingDirection += SetFacingDirection;
            
            _inputService.ChangeWeaponToRight += ChangeWeaponToRight;
            _inputService.ChangeWeaponToLeft += ChangeWeaponToLeft;
            _inputService.ShootButtonPressed += Attack;
        }

        private void OnDisable()
        {
            _playerMovement.FacingDirection -= SetFacingDirection;
            
            _inputService.ChangeWeaponToRight -= ChangeWeaponToRight;
            _inputService.ChangeWeaponToLeft -= ChangeWeaponToLeft;
            _inputService.ShootButtonPressed -= Attack;
        }
        
        private void ChangeWeaponToLeft()
        {
            if (_currentWeaponIndex - 1 < 0)
            {
                _currentWeaponIndex = _weaponArmory.Count - 1;
            }
            else
            {
                _currentWeaponIndex--;
            }
            
            if (!_weaponArmory[_currentWeaponIndex])
            {
                throw new Exception($"ERROR: no weapon with index {_currentWeaponIndex}");
            }
            
            SetWeapon(_currentWeaponIndex);
        }

        private void ChangeWeaponToRight()
        {
            if (_currentWeaponIndex + 1 > _weaponArmory.Count - 1)
            {
                _currentWeaponIndex = 0;
            }
            else
            {
                _currentWeaponIndex++;
            }

            SetWeapon(_currentWeaponIndex);
        }

        private void SetWeapon(int index)
        {
            if (!_weaponArmory[index])
            {
                throw new Exception($"ERROR: no weapon with index {_currentWeaponIndex}");
            }
            
            weaponComponent.ApplySettings(_weaponArmory[index]);
        }

        private void SetFacingDirection(Vector2 direction)
        {
            _facingDirection = direction;
        }

        private void Attack()
        {
            weaponComponent.PerformAttack(_bulletFactory, _facingDirection);
        }
    }
}