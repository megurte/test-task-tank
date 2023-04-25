﻿using System;
using ScriptableObjects;
using UnityEngine;

namespace Character
{
    public class UnitModel<T> : AbstractUnitModel where T : UnitScriptableObjectBase
    {
        public event Action<UnitModel<T>> UnitDied;

        public override Type TargetData => typeof(T);
        
        private float _health;
        public float MovementSpeed {private set; get; }
        public float Defence {private set; get; }
        protected float MaxHealth {private set; get; }
        public float Health
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
            MovementSpeed = config.MovementSpeed;
        }
    }
}