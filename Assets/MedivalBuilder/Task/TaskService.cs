using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Task.Interfaces;
using MedivalBuilder.Task.Realization;
using Zenject;

namespace MedivalBuilder.Task
{
    public class TaskService : ITaskService
    {
        private readonly TickableManager _tickableManager;
        private readonly BuildingsTaskConfig _buildingsTaskConfig;
        private readonly ICharactersStorage _charactersStorage;
        private readonly IInstantiator _instantiator;

        public TaskService(
            BuildingsTaskConfig buildingsTaskConfig,
            ICharactersStorage charactersStorage,
            IInstantiator instantiator)
        {
            _buildingsTaskConfig = buildingsTaskConfig;
            _charactersStorage = charactersStorage;
            _instantiator = instantiator;
        }

        public void CreateBuildingsTask(BuildingsType buildingsType)
        {
            var buildData = _buildingsTaskConfig.GetNextBuildingsLevelData(buildingsType);

            var characterController = _charactersStorage.Get();

            _instantiator.Instantiate<CharactersBuildTask>(new object[] {buildData, characterController});
        }
    }
}