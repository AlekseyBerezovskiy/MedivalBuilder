using Zenject;

namespace MedivalBuilder.Inventory
{
    public class ItemFactory : IFactory<ItemType, Item>
    {
        private readonly IInstantiator _instantiator;
        private readonly ItemView _itemViewAsset;
        private readonly ItemViewConfig _itemViewConfig;

        public ItemFactory(
            IInstantiator instantiator,
            ItemView itemViewAsset,
            ItemViewConfig itemViewConfig)
        {
            _instantiator = instantiator;
            _itemViewAsset = itemViewAsset;
            _itemViewConfig = itemViewConfig;
        }

        public Item Create(ItemType itemType)
        {
            var itemView = _instantiator.InstantiatePrefabForComponent<ItemView>(_itemViewAsset);

            itemView.MeshFilter.mesh = _itemViewConfig.GetData(itemType).Mesh;

            return new Item(itemType, itemView);
        }
    }
}