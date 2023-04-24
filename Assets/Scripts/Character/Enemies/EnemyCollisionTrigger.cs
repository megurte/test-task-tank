using Interfaces;
using UnityEngine;

namespace Character.Enemies
{
    [RequireComponent(typeof(Collider2D)), RequireComponent(typeof(EnemyModel))]
    public class EnemyCollisionTrigger : MonoBehaviour
    {
        private EnemyModel _enemyModel;

        private void Start()
        {
            _enemyModel = GetComponent<EnemyModel>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable) 
                && other.gameObject.TryGetComponent(out IPlayer player))
            {
                damageable.TakeDamage(_enemyModel.Damage);
                _enemyModel.DestroySelf();
            }
        }
    }
}