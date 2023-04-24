using System;
using ScriptableObjects;
using UnityEngine;

namespace Character
{
    public abstract class AbstractUnitModel : MonoBehaviour
    {
        public abstract Type TargetData { get; }
        public abstract void Initialize(UnitScriptableObjectBase data);
    }
}