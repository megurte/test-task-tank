using System;
using ScriptableObjects;
using UnityEngine;

namespace Bullet
{
    public abstract class BulletBase : MonoBehaviour
    {
        public static event Action<BulletBase> OnBulletHit;

        public abstract void Move(Vector2 direction);
        
        public abstract void ChangeSettings(PlayerWeaponSettings settings);

        protected void BulletHit()
        {
            OnBulletHit?.Invoke(this);
        }
    }
}