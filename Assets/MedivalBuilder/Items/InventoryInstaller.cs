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
        }
    }
}