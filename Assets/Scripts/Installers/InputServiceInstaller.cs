using Interfaces;
using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
        // You can add any other input realisations 
        [SerializeField] private KeyboardInput keyboardInput;
        
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().FromInstance(keyboardInput).AsSingle();
        }
    }
}