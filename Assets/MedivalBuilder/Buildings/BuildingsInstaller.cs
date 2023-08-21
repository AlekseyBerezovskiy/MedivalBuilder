using MedivalBuilder.Buildings.Interfaces;
using Zenject;

namespace MedivalBuilder.Buildings
{
    public class BuildingsInstaller : Installer<BuildingsInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IBuildingsStorage>()
                .To<BuildingsStorage>()
                .AsSingle();
        }
    }
}