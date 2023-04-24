using System;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Character.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerCore _playerCore;

        [Inject]
        public void SetDependency(PlayerCore playerCore)
        {
            _playerCore = playerCore;
        }

        private void OnEnable()
        {
            PlayerCore.UnitDied += DestroyPlayerUnit;
        }

        private void OnDestroy()
        {
            PlayerCore.UnitDied += DestroyPlayerUnit;
        }
        
        private void DestroyPlayerUnit(Unit<PlayerUnitSettings> player)
        {
            Destroy(_playerCore.gameObject);
        }
    }
}