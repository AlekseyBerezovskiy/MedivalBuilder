using MedivalBuilder.Camera;
using MedivalBuilder.Consts;
using MedivalBuilder.SceneObjectsStorage;

namespace MedivalBuilder.Application
{
    public class ApplicationLauncher
    {
        private readonly ISceneObjectStorage _sceneObjectStorage;

        public ApplicationLauncher(
            ISceneObjectStorage sceneObjectStorage)
        {
            _sceneObjectStorage = sceneObjectStorage;
            
            StartApplication();
        }
        
        private void StartApplication()
        {
            _sceneObjectStorage
                .CreateFromResourcesAndAdd<CameraView>(
                    ResourcesConsts.CameraViewSource);
        }
    }
}