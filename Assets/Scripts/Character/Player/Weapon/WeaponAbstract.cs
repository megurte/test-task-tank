using Factories;
using ScriptableObjects;
using UnityEngine;

namespace Character.Player.Weapon
{
    public abstract class WeaponAbstract : MonoBehaviour
    {
        public abstract void PerformAttack(BulletFactory factory, Vector2 direction);

        public abstract void ApplySettings(PlayerWeaponSettings settings);
    }
}