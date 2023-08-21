using MedivalBuilder.Buildings;
using MedivalBuilder.Characters;
using MedivalBuilder.Inventory;
using MedivalBuilder.Task;
using Zenject;

namespace MedivalBuilder.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ApplicationModules.Install(Container);
            
            InventoryInstaller.Install(Container);
            
            TaskInstaller.Install(Container);
            
            BuildingsInstaller.Install(Container);
            
            CharactersInstaller.Install(Container);
            
            Container
                .Bind<ApplicationLauncher>()
                .AsSingle()
                .NonLazy();
        }
    }
}