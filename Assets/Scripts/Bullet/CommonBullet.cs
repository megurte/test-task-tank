using System.Collections;
using Character.Player;
using Character.Player.Weapon;
using Interfaces;
using Movement;
using ScriptableObjects;
using UnityEngine;

namespace Bullet
{
    public class CommonBullet : BulletBase
    {
        [SerializeField] private float bulletSpeed;
        private IMovement<Vector2> _moveLogic;
        private float _damage;

        public override void Move(Vector2 direction)
        {
            _moveLogic.Move(direction, bulletSpeed);
        }
        
        public override void ChangeSettings(PlayerWeaponSettings settings)
        {
            _damage = settings.Damage;

            _moveLogic ??= GetComponent<IMovement<Vector2>>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable) 
                && other.gameObject.TryGetComponent(out IEnemy enemy))
            {
                damageable.TakeDamage(_damage);
                BulletHit();
            }
        }
    }
}