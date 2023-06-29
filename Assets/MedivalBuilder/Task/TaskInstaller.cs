using MedivalBuilder.Task.Interfaces;
using Zenject;

namespace MedivalBuilder.Task
{
    public class TaskInstaller : Installer<TaskInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ITaskService>()
                .To<TaskService>()
                .AsSingle();
        }
    }
}