using MedivalBuilder.Characters.Realization;
using MedivalBuilder.Characters.StateMachine;
using Zenject;

namespace MedivalBuilder.Characters.Factory
{
    public class CharactersFactory : IFactory<CharacterController>
    {
        private readonly IInstantiator _instantiator;
        private readonly CharacterView _characterViewPrefab;
        private readonly CharactersConfig _charactersConfig;

        public CharactersFactory(
            IInstantiator instantiator,
            CharacterView characterViewPrefab,
            CharactersConfig charactersConfig)
        {
            _instantiator = instantiator;
            _characterViewPrefab = characterViewPrefab;
            _charactersConfig = charactersConfig;
        }
        
        public CharacterController Create()
        {
            var characterView = _instantiator.InstantiatePrefabForComponent<CharacterView>(_characterViewPrefab);
            
            var characterAnimationController = _instantiator.Instantiate<CharacterAnimationController>(
                new []{characterView.Animator});
            
            var characterStateMachine = _instantiator.Instantiate<CharacterStateMachine>(new []{characterAnimationController});
            
            return _instantiator.Instantiate<CharacterController>(
                new object[]{characterStateMachine, characterView, _charactersConfig.data});
        }
    }
}