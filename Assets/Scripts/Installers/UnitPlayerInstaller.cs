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
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerUnitSettings>().FromInstance(playerUnitSettings).AsSingle().NonLazy();
            Container.Bind<PlayerCore>().FromInstance(playerCore).AsSingle();
        }
    }
}