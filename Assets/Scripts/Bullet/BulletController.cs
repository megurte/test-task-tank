using System;
using System.Collections.Generic;
using Character;
using Factories;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        // Use this to work directly with active enemies
        private List<BulletBase> _activeBullets = new List<BulletBase>();
        private BulletFactory _factory;

        [Inject]
        public void SetDependency(BulletFactory factory)
        {
            _factory = factory;
        }

        private void OnEnable()
        {
            BulletBase.OnBulletHit += ReplaceObject;
        }
        
        private void OnDisable()
        {
            BulletBase.OnBulletHit -= ReplaceObject;
        }
        
        public void Start()
        {
            for (var i = 0; i < _factory.GetPoolSize(); i++)
            {
                var bullet = _factory.SpawnNewObject(transform.position);
                
                _activeBullets.Add(bullet);
            }
        }

        private void ReplaceObject(BulletBase bullet)
        {
            if (bullet == null)
            {
                throw new Exception("ERROR: no object to replace");
            }

            _activeBullets.Remove(bullet);
            _factory.ReturnObjectToPool(bullet);
        }
    }
}