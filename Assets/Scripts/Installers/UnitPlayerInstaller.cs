using Character.Player;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class UnitPlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCore playerCore;
        [SerializeField] private PlayerUnitSettings playerUnitSettings;
        [SerializeField] private Transform playerSpawnPoint;

        private DiContainer _diContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerUnitSettings>().FromInstance(playerUnitSettings).AsSingle().NonLazy();
            
            var playerInstance = Container.InstantiatePrefabForComponent<PlayerCore>(playerCore,
                playerSpawnPoint.position, Quaternion.identity, null);
            Container.Bind<PlayerCore>().FromInstance(playerInstance).AsSingle();
        }
    }
}