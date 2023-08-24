using System;
using System.Collections.Generic;
using UnityEngine;

namespace MedivalBuilder.Inventory
{
    [CreateAssetMenu(fileName = "ItemViewConfig", menuName = "Config/ItemViewConfig")]
    public class ItemViewConfig : ScriptableObject
    {
        [SerializeField] private ItemViewData[] itemViewDatas;

        private Dictionary<ItemType, ItemViewData> _itemDataStorage = new Dictionary<ItemType, ItemViewData>();
        
        [NonSerialized] private bool _isInited;
        
        public ItemViewData GetData(ItemType itemType)
        {
            if (!_isInited)
            {
                _isInited = true;
                Init();
            }
            
            if (_itemDataStorage.ContainsKey(itemType))
            {
                return _itemDataStorage[itemType];
            }
            
            Debug.LogError($"Data with type {itemType} not found!");
            return new ItemViewData();
        }

        private void Init()
        {
            for (int i = 0; i < itemViewDatas.Length; i++)
            {
                _itemDataStorage.Add(itemViewDatas[i].ItemType, itemViewDatas[i]);
            }
        }
    }

    [Serializable]
    public struct ItemViewData
    {
        public ItemType ItemType;
        public Mesh Mesh;
    }
}