using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Services
{
    // Can be extended by separate config with key binds
    public class KeyboardInput : MonoBehaviour, IInputService
    {
        public event Action ChangeWeaponToRight;
        public event Action ChangeWeaponToLeft;
        
        public event Action ShootButtonPressed;
        
        public event Action MovementControlUp;
        public event Action MovementControlDown;
        public event Action MovementControlRight;
        public event Action MovementControlLeft;

        public event Action StopMovementUp;
        public event Action StopMovementDown;
        public event Action StopMovementRight;
        public event Action StopMovementLeft;
        
        private Dictionary<KeyCode, Action> _keyBindings = new Dictionary<KeyCode, Action>();
        
        private void Start()
        {
            // All game key bindings
            _keyBindings[KeyCode.W] = ChangeWeaponToRight;
            _keyBindings[KeyCode.Q] = ChangeWeaponToLeft;
            _keyBindings[KeyCode.X] = ShootButtonPressed;
            
            _keyBindings[KeyCode.UpArrow] = MovementControlUp;
            _keyBindings[KeyCode.DownArrow] = MovementControlDown;
            _keyBindings[KeyCode.RightArrow] = MovementControlRight;
            _keyBindings[KeyCode.LeftArrow] = MovementControlLeft;
        }

        private void Update()
        {
            foreach (var keyBinding in _keyBindings)
            {
                if (Input.GetKeyDown(keyBinding.Key))
                {
                    GetKeyDown(keyBinding.Key, keyBinding.Value);
                }
                
                if (Input.GetKeyUp(keyBinding.Key))
                {
                    GetKeyUp(keyBinding.Key, keyBinding.Value);
                }
            }
        }

        private void GetKeyDown(KeyCode key, Action value)
        {
            value?.Invoke();
        }
        
        private void GetKeyUp(KeyCode key, Action value)
        {
            switch (key)
            {
                case KeyCode.UpArrow:
                    StopMovementUp?.Invoke();
                    break;
                case KeyCode.DownArrow:
                    StopMovementDown?.Invoke();
                    break;
                case KeyCode.RightArrow:
                    StopMovementRight?.Invoke();
                    break;
                case KeyCode.LeftArrow:
                    StopMovementLeft?.Invoke();
                    break;
                default:
                    break;
            }
        }
    }
}