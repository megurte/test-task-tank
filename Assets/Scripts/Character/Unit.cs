using System;
using Constants;
using ScriptableObjects;
using UnityEngine;

namespace Character
{
    public class Unit<T> : AbstractUnit where T : UnitScriptableObjectBase
    {
        public static event Action<Unit<T>> UnitDied;

        public override Type TargetData => typeof(T);

        private float _health;

        private UnitType CurrentUnitType { set; get; }
        public float MovementSpeed {private set; get; }
        protected float Defence {private set; get; }
        protected float MaxHealth {private set; get; }
        protected float Health
        {
            get => _health;
            set
            {
                _health = Mathf.Clamp(value, 0 , MaxHealth);

                if (_health == 0)
                {
                    UnitDied?.Invoke(this);
                }
            }
        }
        
        public void DestroySelf()
        {
            Health = 0;
        }

        public void SetPosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public override void Initialize(UnitScriptableObjectBase configBase)
        {
            if (configBase is T config)
            {
                Initialize(config);
            }
            else
            {
                throw new Exception($"ERROR: Wrong data type. Params: {configBase.GetType()}");
            }
        }
        
        protected virtual void Initialize(T config)
        {
            MaxHealth = config.Health;
            Health = MaxHealth;
            Defence = config.Defence;
            CurrentUnitType = config.UnitType;
            MovementSpeed = config.MovementSpeed;
        }
    }
}