using System;
using System.Collections.Generic;
using Character;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Spawn Config", menuName = "Spawn config")]
    public class SpawnConfig : ScriptableObject
    {
        [SerializeField] private List<EnemySpawnSettings> spawnSettings;
        [SerializeField] private List<SpawnRange> spawnCoordinates;
        [SerializeField][Range(0, 255)] private int maxEnemyPoolSize;
        
        public List<EnemySpawnSettings> SpawnSettings => spawnSettings;
        public List<SpawnRange> SpawnCoordinates
        {
            get
            {
                if (spawnCoordinates.Count > 4)
                {
                    throw new Exception("ERROR: Spawn sides more than 4 ");
                }
                return spawnCoordinates;  
            } 
        }

        public int PoolSize => maxEnemyPoolSize;
    }

    [Serializable]
    public class EnemySpawnSettings
    {
        public EnemyUnitSettings unitSettings;
    }
    
    [Serializable]
    public class SpawnRange
    {
        public Vector2 start;
        public Vector2 end;
    }
}