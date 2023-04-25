using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Unit/Enemy")]
    public class EnemyUnitSettings : UnitScriptableObjectBase
    {
        [SerializeField] private float damage;
        [SerializeField] private Sprite gameSprite;
        [SerializeField] private Color spriteColor;
        
        public Sprite Sprite => gameSprite != null ? gameSprite : throw new Exception("ERROR: enemy sprite does not set");
        public Color SpriteColor => spriteColor;
        public float Damage
        {
            get
            {
                if (damage > 0)
                {
                    return damage;
                }
                Debug.LogWarning($"WARNING: enemy damage is 0 at {this}");
                return damage = 0;;
            } 
        }
    }
}