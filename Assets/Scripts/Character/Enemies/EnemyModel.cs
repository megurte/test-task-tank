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

        public void SetEnemyModel(EnemyUnitSettings settings)
        {
            Initialize(settings);

            Damage = settings.Damage;
        }
    }
}