using Character.Player;
using UnityEngine;
using Zenject;

namespace Utils
{
    public class CameraFollowController : MonoBehaviour
    {
        [SerializeField] private float smoothTime = default;

        private Vector3 _velocity = Vector3.zero;
        private Transform _player;
        
        [Inject]
        public void SetDependency(PlayerModel playerModel)
        {
            _player = playerModel.transform;
        }

        private void LateUpdate()
        {
            if (_player != null)
            {
                var targetPosition = _player.position;
                targetPosition.z = transform.position.z;

                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
            }
        }
    }
}