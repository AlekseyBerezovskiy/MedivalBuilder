using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Characters.Realization;
using MedivalBuilder.Consts;
using Zenject;

namespace MedivalBuilder.Characters
{
    public class CharactersInstaller : Installer<CharactersInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICharactersStorage>()
                .To<CharactersesStorage>()
                .AsSingle();
                
            Container
                .Bind<CharactersConfig>()
                .FromScriptableObjectResource(ResourcesConsts.CharactersConfigSource)
                .AsSingle();

            Container
                .Bind<CharacterView>()
                .FromResources(ResourcesConsts.CharacterViewSource)
                .AsSingle();

            Container
                .Bind<CharactersFactory>()
                .AsSingle();
        }
    }
}