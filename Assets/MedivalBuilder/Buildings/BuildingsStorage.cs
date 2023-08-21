using System.Collections.Generic;
using MedivalBuilder.Buildings.Interfaces;
using MedivalBuilder.Task.Realization;
using UnityEngine;

namespace MedivalBuilder.Buildings
{
    public class BuildingsStorage : IBuildingsStorage
    {
        private Dictionary<BuildingsType, BuildingController> _storage =
            new Dictionary<BuildingsType, BuildingController>();
        
        public BuildingController GetBuilding(BuildingsType type)
        {
            var asset = Resources.Load<BuildingView>("WoodenStorage");

            var buildingView = Object.Instantiate(asset);
            
            return new BuildingController(buildingView);
        }
    }
}