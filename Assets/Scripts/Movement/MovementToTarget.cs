using System.Collections;
using Interfaces;
using UnityEngine;

namespace Movement
{
    public class MovementToTarget : MonoBehaviour, IMovement<Transform>
    {
        private Transform _playerTransformRef;
        
        public void Move(Transform target, float speed)
        {
            StartCoroutine(MoveCoroutine(target, speed));
        }
        
        private IEnumerator MoveCoroutine(Transform target, float speed)
        {
            _playerTransformRef = target;
            
            while (_playerTransformRef != null && transform.position != _playerTransformRef.position) 
            {
                transform.position = Vector3.MoveTowards(transform.position, _playerTransformRef.position,
                    speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}