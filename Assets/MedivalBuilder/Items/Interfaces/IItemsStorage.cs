namespace MedivalBuilder.Inventory.Interfaces
{
    public interface IItemsStorage
    {
        void Add(Item item);
        Item Get(ItemType itemType);
    }
}