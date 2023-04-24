using System.Collections.Generic;
using System.Linq;
using Character;
using Character.Enemies;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class EnemyFactory : GenericFactory<UnitModel<EnemyUnitSettings>>
    {
        [SerializeField] private UnitModel<EnemyUnitSettings> enemyDummyPrefab;
        
        private readonly List<UnitModel<EnemyUnitSettings>> _enemyPool = new List<UnitModel<EnemyUnitSettings>>();
        private DiContainer _diContainer;
        
        [Inject]
        public void SetDependency(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public override UnitModel<EnemyUnitSettings> SpawnNewObject(Vector2 position)
        {
            foreach (var enemy in _enemyPool.Where(enemy => !enemy.gameObject.activeInHierarchy))
            {
                enemy.gameObject.SetActive(true);
                enemy.SetPosition(position);
                return enemy;
            }

            // If there are no inactive enemies in the pool, create a new one
            var newEnemy = _diContainer.InstantiatePrefabForComponent<UnitModel<EnemyUnitSettings>>(enemyDummyPrefab,
                transform);
            
            newEnemy.SetPosition(position);
            _enemyPool.Add(newEnemy);
            return newEnemy;
        }
        
        public override void ReturnObjectToPool(UnitModel<EnemyUnitSettings> enemy)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}