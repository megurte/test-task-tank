using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Character.Enemies
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyModel : UnitModel<EnemyUnitSettings>, IEnemy
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
    }
}