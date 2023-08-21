using MedivalBuilder.Consts;
using MedivalBuilder.Task.Interfaces;
using MedivalBuilder.Task.Realization;
using Zenject;

namespace MedivalBuilder.Task
{
    public class TaskInstaller : Installer<TaskInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<BuildingsTaskConfig>()
                .FromScriptableObjectResource(ResourcesConsts.BuildTaskConfigSource)
                .AsSingle();
            
            Container
                .Bind<ITaskService>()
                .To<TaskService>()
                .AsSingle();
        }
    }
}