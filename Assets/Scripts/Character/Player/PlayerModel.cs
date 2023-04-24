using Interfaces;
using ScriptableObjects;
using Zenject;

namespace Character.Player
{
    public class PlayerModel : UnitModel<PlayerUnitSettings>, IPlayer
    {
        [Inject]
        public void SetDependency(PlayerUnitSettings settings)
        {
            Initialize(settings);
        }
    }
}