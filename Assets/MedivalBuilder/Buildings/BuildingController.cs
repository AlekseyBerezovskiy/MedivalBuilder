using MedivalBuilder.Inventory;
using UnityEngine;

namespace MedivalBuilder.Buildings
{
    public class BuildingController
    {
        public BuildingView BuildingView { get; private set; }
        
        public BuildingController(BuildingView buildingView)
        {
            BuildingView = buildingView;
        }
        
        public void AddItem(ItemType itemType)
        {
            Debug.Log(itemType.ToString());
        }
    }
}