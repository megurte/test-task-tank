using Factories;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private BulletFactory bulletFactory;

        public override void InstallBindings()
        {
            Container.Bind<BulletFactory>().FromInstance(bulletFactory).AsSingle();
            Container.Bind<EnemyFactory>().FromInstance(enemyFactory).AsSingle();
        }
    }
}