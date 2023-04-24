using Character.MovementLogics;
using Character.Player;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Bullet
{
    public class CommonBullet : BulletBase
    {
        [SerializeField] private float bulletSpeed;
        private MovementInDirection _moveLogic;
        private float _damage;

        private void OnEnable()
        {
            WeaponController.WeaponChanged += ChangeSettings;
        }
        
        private void OnDestroy()
        {
            WeaponController.WeaponChanged -= ChangeSettings;
        }

        public override void Move(Vector2 direction)
        {
            _moveLogic.Move(direction, bulletSpeed);
        }
        
        public override void ChangeSettings(PlayerWeaponSettings settings)
        {
            _damage = settings.Damage;

            _moveLogic ??= gameObject.AddComponent<MovementInDirection>();
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