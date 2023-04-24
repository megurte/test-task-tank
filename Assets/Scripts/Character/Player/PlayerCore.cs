using Interfaces;
using ScriptableObjects;
using Zenject;

namespace Character.Player
{
    public class PlayerCore : Unit<PlayerUnitSettings>, IDamageable, IPlayer
    {
        [Inject]
        public void SetDependency(PlayerUnitSettings settings)
        {
            Initialize(settings);
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
            Health -= amount * Defence;
        }
    }
}