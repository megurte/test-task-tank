using ScriptableObjects;
using UnityEngine;

namespace Character.Enemies
{
    [RequireComponent(typeof(EnemyModel)), RequireComponent(typeof(EnemyView))]
    public class EnemyController : MonoBehaviour
    {
        private EnemyModel _enemyModel;
        private EnemyView _enemyView;
        
        public void Awake()
        {
            _enemyModel = GetComponent<EnemyModel>();
            _enemyView = GetComponent<EnemyView>();
        }

        public void SetSettings(EnemyUnitSettings settings)
        {
            _enemyModel.SetEnemyModel(settings);
            _enemyView.SetEnemyView(settings);
        }
    }
}