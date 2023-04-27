using System.Collections;
using Constants;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Bullet
{
    public class CommonBulletModel : BulletAbstract
    {
        private float _bulletSpeed => ValueConstants.BulletDefaultSpeed;
        private float _hideDelay = ValueConstants.BulletHideDelay;
        private IMovement<Vector2> _moveLogic;
        private float _damage;

        private void OnEnable()
        {
            StartCoroutine(HideAfterDelay());
        }

        public override void Move(Vector2 direction)
        {
            _moveLogic.Move(direction, _bulletSpeed);
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
        
        private IEnumerator HideAfterDelay () {
            yield return new WaitForSeconds(_hideDelay);
            BulletHit();
        }
    }
}