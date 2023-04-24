using System;
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
            PlayerModel.UnitDied += DestroyPlayerUnit;
        }

        private void OnDestroy()
        {
            PlayerModel.UnitDied += DestroyPlayerUnit;
        }
        
        private void DestroyPlayerUnit(UnitModel<PlayerUnitSettings> player)
        {
            _playerModel.gameObject.SetActive(false);
        }
    }
}