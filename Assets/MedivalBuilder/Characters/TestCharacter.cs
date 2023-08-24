using MedivalBuilder.Inventory;
using MedivalBuilder.Inventory.Interfaces;
using MedivalBuilder.Task.Interfaces;
using MedivalBuilder.Task.Realization;
using UnityEngine;
using Zenject;

namespace MedivalBuilder.Characters
{
    public class TestCharacter : MonoBehaviour
    {
        private ITaskService _taskService;

        [Inject]
        private void Inject(
            ITaskService taskService)
        {
            _taskService = taskService;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _taskService.CreateBuildingsTask(BuildingsType.WoodenStorage);
            }
        }
    }
}