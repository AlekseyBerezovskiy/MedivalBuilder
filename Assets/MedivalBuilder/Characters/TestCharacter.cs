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
        [SerializeField] private ItemView itemView;
        
        private ITaskService _taskService;
        private IItemsStorage _itemsStorage;
        
        [Inject]
        private void Inject(
            ITaskService taskService,
            IItemsStorage itemsStorage)
        {
            _itemsStorage = itemsStorage;
            _taskService = taskService;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var item = new Item(ItemType.Wood, itemView);
                _itemsStorage.Add(item);
                
                _taskService.CreateBuildingsTask(BuildingsType.WoodenStorage);
            }
        }
    }
}