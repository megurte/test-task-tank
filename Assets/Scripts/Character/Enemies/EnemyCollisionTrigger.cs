using Interfaces;
using UnityEngine;

namespace Character.Enemies
{
    [RequireComponent(typeof(Collider2D)), RequireComponent(typeof(EnemyCore))]
    public class EnemyCollisionTrigger : MonoBehaviour
    {
        private EnemyCore _enemyCore;

        private void Start()
        {
            _enemyCore = GetComponent<EnemyCore>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable) 
                && other.gameObject.TryGetComponent(out IPlayer player))
            {
                damageable.TakeDamage(_enemyCore.Damage);
                _enemyCore.DestroySelf();
            }
        }
    }
}