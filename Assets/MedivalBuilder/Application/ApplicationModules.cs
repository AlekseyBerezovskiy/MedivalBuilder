using MedivalBuilder.SceneObjectsStorage;
using Zenject;

namespace MedivalBuilder.Application
{
    public class ApplicationModules : Installer<ApplicationModules>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISceneObjectStorage>()
                .To<SceneObjectStorage>()
                .AsSingle();
        }
    }
}