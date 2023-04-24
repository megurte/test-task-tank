using Factories;
using ScriptableObjects;
using UnityEngine;

namespace Character.Player.Weapon
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CommonCannonWeapon : WeaponAbstract
    {
        private SpriteRenderer _spriteRenderer;
        private PlayerWeaponSettings _weaponSettings;

        private void OnEnable()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public override void PerformAttack(BulletFactory factory, Vector2 direction)
        {
            var bullet = factory.SpawnNewObject(transform.position);
            bullet.ChangeSettings(_weaponSettings);
            bullet.Move(direction);
        }

        public override void ApplySettings(PlayerWeaponSettings settings)
        {
            _weaponSettings = settings;
            _spriteRenderer.sprite = settings.Sprite;
        }
    }
}