using MedivalBuilder.Camera;
using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Consts;
using MedivalBuilder.Level;
using MedivalBuilder.SceneObjectsStorage;

namespace MedivalBuilder.Application
{
    public class ApplicationLauncher
    {
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly CharactersFactory _charactersFactory;
        private readonly ICharactersStorage _charactersStorage;

        public ApplicationLauncher(
            ISceneObjectStorage sceneObjectStorage,
            CharactersFactory charactersFactory,
            ICharactersStorage charactersStorage)
        {
            _sceneObjectStorage = sceneObjectStorage;
            _charactersFactory = charactersFactory;
            _charactersStorage = charactersStorage;

            StartApplication();
        }
        
        private void StartApplication()
        {
            _sceneObjectStorage
                .CreateFromResourcesAndAdd<CameraView>(
                    ResourcesConsts.CameraViewSource);
            
            _sceneObjectStorage
                .CreateFromResourcesAndAdd<LevelView>(
                    ResourcesConsts.LevelViewSource);

            _charactersStorage.Add(_charactersFactory.Create());
        }
    }
}