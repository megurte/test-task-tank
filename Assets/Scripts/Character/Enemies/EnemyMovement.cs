using Character.Player;
using Interfaces;
using Movement;
using UnityEngine;
using Zenject;

namespace Character.Enemies
{
    [RequireComponent(typeof(Rigidbody2D)),
     RequireComponent(typeof(EnemyModel)),
     RequireComponent(typeof(MovementToTarget))]
    public class EnemyMovement : MonoBehaviour
    {
        private PlayerModel _player;
        private EnemyModel _enemyModel;
        private IMovement<Transform> _moveLogic;
        private bool _isMoving = default;

        [Inject]
        public void SetDependency(PlayerModel playerModel)
        {
            _enemyModel = GetComponent<EnemyModel>();
            _player = playerModel;
        }

        private void Update()
        {
            if (_player == null) return;

            if (_moveLogic == null || _isMoving) return;
            
            _moveLogic.Move(_player.transform, _enemyModel.MovementSpeed);
            _isMoving = true;
        }

        private void OnEnable()
        {
            _moveLogic = GetComponent<IMovement<Transform>>();
        }

        private void OnDisable()
        {
            _isMoving = false;
        }
    }
}