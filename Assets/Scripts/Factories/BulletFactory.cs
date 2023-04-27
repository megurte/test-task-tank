using System.Collections.Generic;
using System.Linq;
using Bullet;
using Constants;
using UnityEngine;

namespace Factories
{
    public class BulletFactory : GenericFactory<BulletAbstract>
    {
        [SerializeField] private BulletAbstract bulletPrefab;

        private const int PoolSize = ValueConstants.BulletPoolSize;
        private List<BulletAbstract> _bulletPool;

        public override BulletAbstract SpawnNewObject(Vector2 position)
        {
            _bulletPool ??= new List<BulletAbstract>();

            foreach (var bullet in _bulletPool.Where(bullet => !bullet.gameObject.activeInHierarchy))
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.position = position;
                
                return bullet;
            }

            var newBullet = Instantiate(bulletPrefab, position,
                Quaternion.identity, transform);
                
            _bulletPool.Add(newBullet);
            
            return newBullet;
        }

        public override void ReturnObjectToPool(BulletAbstract targetObject)
        {
            targetObject.gameObject.SetActive(false);
        }
        
        public int GetPoolSize()
        {
            return PoolSize;
        }
    }
}