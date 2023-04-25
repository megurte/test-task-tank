using System;
using Character.Enemies;
using Character.Player;
using Interfaces;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(AbstractUnitModel))]
    public class DamageReceiverModule : MonoBehaviour, IDamageable
    {
        private AbstractUnitModel _unit;

        private void Start()
        {
            _unit = GetComponent<AbstractUnitModel>();
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

            switch (_unit)
            {
                case PlayerModel playerModel:
                    playerModel.Health -= amount * playerModel.Defence;
                    break;
                case EnemyModel enemyModel:
                    enemyModel.Health -= amount * enemyModel.Defence;
                    break;
                default:
                    throw new Exception("ERROR: Unknown unit type");
            }
        }
    }
}