using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private InputService inputService;
        
        public override void InstallBindings()
        {
            Container.Bind<InputService>().FromInstance(inputService).AsSingle();
        }
    }
}