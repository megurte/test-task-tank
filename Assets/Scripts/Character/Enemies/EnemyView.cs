using ScriptableObjects;
using UnityEngine;

namespace Character.Enemies
{
    
    public class EnemyView : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public void SetEnemyView(EnemyUnitSettings settings)
        {
            _spriteRenderer ??= GetComponent<SpriteRenderer>();

            _spriteRenderer.sprite = settings.Sprite;
            _spriteRenderer.color = settings.SpriteColor;
        }
    }
}