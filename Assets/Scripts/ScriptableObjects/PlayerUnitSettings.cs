using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New player", menuName = "Unit/Player")]
    public sealed class PlayerUnitSettings : UnitScriptableObjectBase
    {
        [SerializeField] private List<PlayerWeaponSettings> availableWeapons;

        public List<PlayerWeaponSettings> AvailableWeapons
        {
            get
            {
                if (availableWeapons.Count == 0)
                {
                    throw new Exception("ERROR: no available weapons in player settings");
                }
                return availableWeapons;
            }
        }
    }
}