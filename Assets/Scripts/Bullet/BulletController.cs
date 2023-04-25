using System;
using System.Collections.Generic;
using Factories;
using UnityEngine;
using Zenject;

namespace Bullet
{
    public class BulletController : MonoBehaviour
    {
        private BulletFactory _factory;
        private List<BulletAbstract> _bulletCollection;

        [Inject]
        public void SetDependency(BulletFactory factory)
        {
            _factory = factory;
        }

        public void Start()
        {
            _bulletCollection = new List<BulletAbstract>();
            
            for (var i = 0; i < _factory.GetPoolSize(); i++)
            {
                var bullet = _factory.SpawnNewObject(transform.position);

                bullet.OnBulletHit += ReplaceObject;
                _bulletCollection.Add(bullet);
            }

            // To prevent using the same object in cycle of SpawnNewObject()
            foreach (var bullet in _bulletCollection)
            {
                bullet.gameObject.SetActive(false);
            }
        }

        private void ReplaceObject(BulletAbstract bullet)
        {
            if (bullet == null)
            {
                throw new Exception("ERROR: no object to replace");
            }
            
            _factory.ReturnObjectToPool(bullet);
        }
    }
}