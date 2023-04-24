using System;
using System.Collections.Generic;
using Bullet;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class BulletFactory : GenericFactory<BulletBase>
    {
        [SerializeField] private BulletBase bulletPrefab;
        [SerializeField] private int poolSize = 20;

        private Queue<BulletBase> _bulletPool;
        private readonly List<BulletBase> _enemyPool = new List<BulletBase>();
        private DiContainer _diContainer;

        [Inject]
        public void SetDependency(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        private void Awake()
        {
            BulletBase.OnBulletHit += ReturnObjectToPool;

            _bulletPool = new Queue<BulletBase>();

            for (var i = 0; i < poolSize; i++)
            {
                var bullet = _diContainer.InstantiatePrefabForComponent<BulletBase>(bulletPrefab, transform);
                
                bullet.gameObject.SetActive(false);
                _enemyPool.Add(bullet);
            }
        }

        public override BulletBase SpawnNewObject(Vector2 position)
        {
            if (_bulletPool.Count > 0)
            {
                var bullet = _bulletPool.Dequeue();
                bullet.gameObject.SetActive(true);
                bullet.transform.position = position;
                return bullet;
            }
            else
            {
                var bullet = _diContainer.InstantiatePrefabForComponent<BulletBase>(bulletPrefab, position,
                    Quaternion.identity, transform);
                
                return bullet;
            }
        }

        public override void ReturnObjectToPool(BulletBase targetObject)
        {
            targetObject.gameObject.SetActive(false);
            _bulletPool.Enqueue(targetObject);
        }

        private void OnDisable()
        {
            BulletBase.OnBulletHit -= ReturnObjectToPool;
        }

        public int GetPoolSize()
        {
            return poolSize;
        }
    }
}