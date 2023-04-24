using System;
using Interfaces;
using ScriptableObjects;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(AbstractUnitModel))]
    public class DamageReceiverModule : MonoBehaviour, IDamageable
    {
        private UnitModel<UnitScriptableObjectBase> _unit;

        private void Start()
        {
            _unit = GetComponent<UnitModel<UnitScriptableObjectBase>>();
        }

        public void TakeDamage(float amount)
        {
            /// Формула указанная в ТЗ довольно странная.
            /// Если это процент защиты от 0 до 1, то в этом кейсе,
            /// когда у юнита 0 защиты, он получит 0 урона, а в случае,
            /// если у юнита 1 защита, то он получит максимальный урон.
            /// Такая же ситуация, если защита не является процентом, а просто показатель.
            /// Чем больше защита, тем больше урона получает юнит.
            /// На реальном проекте я бы уточнил этот момент у фичаовнера/человека, который состовлял ТЗ/Док,
            /// что конкретно имелось ввиду.

            if (_unit == null)
            {
                throw new Exception("ERROR: Cannot apply damage to unit without reference");
            }
            
            _unit.Health -= amount * _unit.Defence;
        }
    }
}