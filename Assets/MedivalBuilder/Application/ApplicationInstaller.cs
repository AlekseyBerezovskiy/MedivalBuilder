using MedivalBuilder.Characters;
using MedivalBuilder.Task;
using Zenject;

namespace MedivalBuilder.Application
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ApplicationModules.Install(Container);
            
            TaskInstaller.Install(Container);
            
            CharactersInstaller.Install(Container);
            
            Container
                .Bind<ApplicationLauncher>()
                .AsSingle()
                .NonLazy();
        }
    }
}