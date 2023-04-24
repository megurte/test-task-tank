using System;
using Character.MovementLogics;
using Character.Player;
using UnityEngine;
using Zenject;

namespace Character.Enemies
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(EnemyCore))]
    public class EnemyMovement : MonoBehaviour
    {
        private PlayerCore _player;
        private EnemyCore _enemyCore;
        private MovementToTarget _moveLogic;
        private bool _isMoving = default;

        [Inject]
        public void SetDependency(PlayerCore playerCore)
        {
            _enemyCore = GetComponent<EnemyCore>();
            _player = playerCore;
        }

        private void Update()
        {
            if (_player == null) return;

            if (_moveLogic == null || _isMoving) return;
            
            _moveLogic.Move(_player.transform, _enemyCore.MovementSpeed);
            _isMoving = true;
        }

        private void OnEnable()
        {
            _moveLogic ??= gameObject.AddComponent<MovementToTarget>();
        }

        private void OnDisable()
        {
            _isMoving = false;
        }
    }
}