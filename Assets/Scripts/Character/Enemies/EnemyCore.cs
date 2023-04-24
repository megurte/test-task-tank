using Character.MovementLogics;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Character.Enemies
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyCore : Unit<EnemyUnitSettings>, IEnemy, IDamageable
    {
        public float Damage { private set; get; }
        
        private SpriteRenderer _spriteRenderer;

        public void SetSettings(EnemyUnitSettings settings)
        {
            Initialize(settings);

            Damage = settings.Damage;

            _spriteRenderer ??= GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = settings.Sprite;
            _spriteRenderer.color = settings.SpriteColor;

        }

        public void TakeDamage(float amount)
        {
            Health -= amount * Defence;
        }
    }
}