using MedivalBuilder.Consts;
using MedivalBuilder.Inventory.Interfaces;
using Zenject;

namespace MedivalBuilder.Inventory
{
    public class InventoryInstaller : Installer<InventoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IItemsStorage>()
                .To<ItemsStorage>()
                .AsSingle();

            Container
                .Bind<ItemViewConfig>()
                .FromScriptableObjectResource(ResourcesConsts.ItemViewConfigSource)
                .AsSingle();
            
            Container
                .Bind<ItemView>()
                .FromResources(ResourcesConsts.ItemViewSource)
                .AsSingle();

            Container
                .Bind<ItemFactory>()
                .AsSingle();
        }
    }
}