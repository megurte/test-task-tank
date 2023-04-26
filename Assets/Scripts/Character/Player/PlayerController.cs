using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Character.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerModel _playerModel;

        [Inject]
        public void SetDependency(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void OnEnable()
        {
            _playerModel.UnitDied += DestroyPlayerUnit;
        }

        private void DestroyPlayerUnit(UnitModel<PlayerUnitSettings> player)
        {
            _playerModel.UnitDied -= DestroyPlayerUnit;
            _playerModel.gameObject.SetActive(false);
        }
    }
}