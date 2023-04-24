using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
    public class PlayerWeaponSettings : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private Sprite gameSprite;
        
        public Sprite Sprite => gameSprite != null ? gameSprite : throw new Exception("ERROR: enemy sprite does not set");
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