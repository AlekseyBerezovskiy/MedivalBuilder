using MedivalBuilder.Camera;
using MedivalBuilder.Characters.Factory;
using MedivalBuilder.Characters.Interfaces;
using MedivalBuilder.Consts;
using MedivalBuilder.Inventory;
using MedivalBuilder.Inventory.Interfaces;
using MedivalBuilder.Level;
using MedivalBuilder.SceneObjectsStorage;
using UnityEngine;

namespace MedivalBuilder.Application
{
    public class ApplicationLauncher
    {
        private readonly ISceneObjectStorage _sceneObjectStorage;
        private readonly CharactersFactory _charactersFactory;
        private readonly ICharactersStorage _charactersStorage;
        private readonly ItemFactory _itemFactory;
        private readonly IItemsStorage _itemsStorage;

        public ApplicationLauncher(
            ISceneObjectStorage sceneObjectStorage,
            CharactersFactory charactersFactory,
            ICharactersStorage charactersStorage,
            ItemFactory itemFactory,
            IItemsStorage itemsStorage)
        {
            _sceneObjectStorage = sceneObjectStorage;
            _charactersFactory = charactersFactory;
            _charactersStorage = charactersStorage;
            _itemFactory = itemFactory;
            _itemsStorage = itemsStorage;

            StartApplication();
        }
        
        private void StartApplication()
        {
            _sceneObjectStorage
                .CreateFromResourcesAndAdd<CameraView>(
                    ResourcesConsts.CameraViewSource);
            
            var levelView = _sceneObjectStorage
                .CreateFromResourcesAndAdd<LevelView>(
                    ResourcesConsts.LevelViewSource);

            CreateItems(ItemType.Wood, levelView.WoodItemAnchors);
            CreateItems(ItemType.Stone, levelView.StoneItemAnchors);
            
            _charactersStorage.Add(_charactersFactory.Create());
        }

        private void CreateItems(ItemType itemType, Transform[] anchors)
        {
            for (int i = 0; i < anchors.Length; i++)
            {
                var item = _itemFactory.Create(itemType);

                var itemViewTransform = item.ItemView.transform;
                itemViewTransform.SetParent(anchors[i]);
                itemViewTransform.localPosition = Vector3.zero;
                
                _itemsStorage.Add(item);
            }
        }
    }
}