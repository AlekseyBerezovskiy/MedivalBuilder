using System.Collections.Generic;
using MedivalBuilder.Inventory.Interfaces;

namespace MedivalBuilder.Inventory
{
    public class ItemsStorage : IItemsStorage
    {
        private List<Item> _woodenItems = new List<Item>();
        private List<Item> _stoneItems = new List<Item>();
        
        public void Add(Item item)
        {
            if (item.ItemType == ItemType.Stone)
            {
                if (!_stoneItems.Contains(item))
                {
                    _stoneItems.Add(item);
                }
            }
            else if (item.ItemType == ItemType.Wood)
            {
                if (!_woodenItems.Contains(item))
                {
                    _woodenItems.Add(item);
                }
            }
        }

        public Item Get(ItemType itemType)
        {
            if (itemType == ItemType.Stone)
            {
                if (_stoneItems.Count > 0)
                {
                    var item = _stoneItems[0];
                    _stoneItems.RemoveAt(0);
                    return item;
                }
            }
            else if (itemType == ItemType.Wood)
            {
                if (_woodenItems.Count > 0)
                {
                    var item = _woodenItems[0];
                    _woodenItems.RemoveAt(0);
                    return item;
                }
            }
            return null;
        }
    }
}