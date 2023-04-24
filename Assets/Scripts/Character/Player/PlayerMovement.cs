using System;
using Services;
using UnityEngine;
using Zenject;

namespace Character.Player
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(PlayerModel)), RequireComponent(typeof(PlayerModel))]
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<Vector2> FacingDirection;
        
        private Vector2 _moveDirection;
        private Rigidbody2D _rigidbody2D;
        private InputService _inputService;
        private PlayerModel _playerModel;
        
        [Inject]
        public void SetDependency(InputService inputService)
        {
            _inputService = inputService;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerModel = GetComponent<PlayerModel>();
        }

        private void FixedUpdate()
        {
            if (_moveDirection != Vector2.zero)
            {
                _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection * _playerModel.MovementSpeed 
                    * Time.fixedDeltaTime);
            }
        }
        
        private void MovePlayer(Vector3 direction)
        {
            _moveDirection = direction.normalized;
            transform.up = _moveDirection;
        }

        private void StopPlayer()
        {
            _moveDirection = Vector2.zero;
        }
        
        private void OnEnable()
        {
            _inputService.MovementControlUp += MovePlayerUp;
            _inputService.MovementControlDown += MovePlayerDown;
            _inputService.MovementControlRight += MovePlayerRight;
            _inputService.MovementControlLeft += MovePlayerLeft;

            _inputService.StopMovementUp += StopPlayerUp;
            _inputService.StopMovementDown += StopPlayerDown;
            _inputService.StopMovementRight += StopPlayerRight;
            _inputService.StopMovementLeft += StopPlayerLeft;
        }

        private void OnDisable()
        {
            _inputService.MovementControlUp -= MovePlayerUp;
            _inputService.MovementControlDown -= MovePlayerDown;
            _inputService.MovementControlRight -= MovePlayerRight;
            _inputService.MovementControlLeft -= MovePlayerLeft;

            _inputService.StopMovementUp -= StopPlayerUp;
            _inputService.StopMovementDown -= StopPlayerDown;
            _inputService.StopMovementRight -= StopPlayerRight;
            _inputService.StopMovementLeft -= StopPlayerLeft;
        }

        private void MovePlayerUp()
        {
            MovePlayer(Vector2.up);
            FacingDirection?.Invoke(Vector2.up);
        }

        private void MovePlayerDown()
        {
            MovePlayer(Vector2.down);
            FacingDirection?.Invoke(Vector2.down);
        }

        private void MovePlayerRight()
        {
            MovePlayer(Vector2.right);
            FacingDirection?.Invoke(Vector2.right);
        }

        private void MovePlayerLeft()
        {
            MovePlayer(Vector2.left);
            FacingDirection?.Invoke(Vector2.left);
        }

        private void StopPlayerUp()
        {
            if (_moveDirection == Vector2.up)
            {
                StopPlayer();
            }
        }

        private void StopPlayerDown()
        {
            if (_moveDirection == Vector2.down)
            {
                StopPlayer();
            }
        }

        private void StopPlayerRight()
        {
            if (_moveDirection == Vector2.right)
            {
                StopPlayer();
            }
        }

        private void StopPlayerLeft()
        {
            if (_moveDirection == Vector2.left)
            {
                StopPlayer();
            }
        }
    }
}