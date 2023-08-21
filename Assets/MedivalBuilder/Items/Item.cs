namespace MedivalBuilder.Inventory
{
    public class Item
    {
        public ItemView ItemView { get; }
        public ItemType ItemType { get; }

        public Item(ItemType itemType, ItemView itemView)
        {
            ItemType = itemType;
            ItemView = itemView;
        }
    }

    public enum ItemType
    {
        Wood,
        Stone
    }
}