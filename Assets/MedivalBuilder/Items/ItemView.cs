using MedivalBuilder.Inventory.Interfaces;
using UnityEngine;
using Zenject;

namespace MedivalBuilder.Inventory
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private ItemType itemType;

        [Inject]
        private void Inject(IItemsStorage itemsStorage)
        {
            itemsStorage.Add(new Item(itemType,this));
        }
    }
}