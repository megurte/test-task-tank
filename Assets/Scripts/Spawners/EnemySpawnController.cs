using System;
using System.Collections.Generic;
using Character;
using Character.Enemies;
using Factories;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using Utils;

namespace Spawners
{
    public class EnemySpawnController : MonoBehaviour
    {
        // Use this to work directly with active enemies
        private List<UnitModel<EnemyUnitSettings>> _activeEnemies = new List<UnitModel<EnemyUnitSettings>>();
        private SpawnConfig _spawnConfig;
        private EnemyFactory _enemyFactory;

        [Inject]
        public void SetDependency(SpawnConfig spawnConfig, EnemyFactory enemyFactory)
        {
            _spawnConfig = spawnConfig;
            _enemyFactory = enemyFactory;
        }

        public void Start()
        {
            for (var i = 0; i < _spawnConfig.PoolSize; i++)
            {
                GenerateSettingsForEnemySpawn();
            }
        }

        private void ReplaceUnit(UnitModel<EnemyUnitSettings> unitModel)
        {
            if (unitModel == null)
            {
                throw new Exception("ERROR: no unit ro replace");
            }

            _activeEnemies.Remove(unitModel);
            _enemyFactory.ReturnObjectToPool(unitModel);
            GenerateSettingsForEnemySpawn();
        }

        private void GenerateSettingsForEnemySpawn()
        {
            var spawnSide = UtilsBase.GetRandomNumberFromRange(0, _spawnConfig.SpawnCoordinates.Count);
            var enemyPosition = UtilsBase.GetRandomCoordinatesFromRange(_spawnConfig.SpawnCoordinates[spawnSide].start,
                _spawnConfig.SpawnCoordinates[spawnSide].end);
            var enemy = _enemyFactory.SpawnNewObject(enemyPosition);
            var settingsIndex = UtilsBase.GetRandomNumberFromRange(0, _spawnConfig.SpawnSettings.Count);
            var enemySettings = _spawnConfig.SpawnSettings[settingsIndex].unitSettings;

            if (enemySettings == null || enemySettings.GetType() != typeof(EnemyUnitSettings))
            {
                throw new Exception($"ERROR: Enemy settings are incorrect. {enemySettings}");
            }
            
            _activeEnemies.Add(enemy);
            enemy.UnitDied += ReplaceUnit;
            
            var enemyController = enemy.gameObject.GetComponent<EnemyController>();

            if (enemyController == null)
            {
                throw new Exception($"ERROR: No enemy controller in object.");
            }
            
            enemyController.SetSettings(enemySettings);
        }
    }
}