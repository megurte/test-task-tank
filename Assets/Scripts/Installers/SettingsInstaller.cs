using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SettingsInstaller : MonoInstaller
    {
        [SerializeField] private SpawnConfig spawnConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<SpawnConfig>().FromInstance(spawnConfig).AsSingle();
        }
    }
}