using System;
using Constants;
using UnityEngine;

namespace ScriptableObjects
{
    public class UnitScriptableObjectBase : ScriptableObject
    {
        [SerializeField][Range(0, 1f)] protected float defence;
        [SerializeField] protected float health;
        [SerializeField] protected float movementSpeed;

        public float Defence => defence;
        public float Health => health > 0 
            ? health 
            : throw new Exception($"ERROR: Health for unit less or equal 0 at {this}");
        public float MovementSpeed => movementSpeed > 0 
            ? movementSpeed 
            : throw new Exception($"ERROR: Movement speed for unit less or equal 0 at {this}");
    }
}