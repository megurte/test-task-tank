using System.Collections;
using Interfaces;
using UnityEngine;

namespace Movement
{
    public class MovementInDirection : MonoBehaviour, IMovement<Vector2>
    {
        public void Move(Vector2 direction, float speed)
        {
            StartCoroutine(MoveCoroutine(direction, speed));
        }
        
        private IEnumerator MoveCoroutine(Vector2 direction, float speed) {
            while (true) 
            {
                transform.position += (Vector3)direction * speed * Time.deltaTime;
                yield return null;
            }
        }
    }
}