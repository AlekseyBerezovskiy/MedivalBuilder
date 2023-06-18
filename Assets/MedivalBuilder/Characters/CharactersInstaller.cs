using MedivalBuilder.Characters.StateMachine;
using MedivalBuilder.Characters.StateMachine.Interfaces;
using Zenject;

namespace MedivalBuilder.Characters
{
    public class CharactersInstaller : Installer<CharactersInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICharacterStateMachine>()
                .To<CharacterStateMachine>()
                .AsSingle();
        }
    }
}