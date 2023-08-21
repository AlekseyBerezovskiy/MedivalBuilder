using System;
using System.Collections.Generic;
using UnityEngine;

namespace MedivalBuilder.Task.Realization
{
    [CreateAssetMenu(fileName = "BuildDataConfig", menuName = "Config/BuildDataConfig")]
    public class BuildDataConfig : ScriptableObject
    {
        public BuildingsType BuildingsType;

        [SerializeField] private List<BuildData> buildDatas;

        public BuildData GetNextBuildingsLevelData()
        {
            for (int i = 0; i < buildDatas.Count; i++)
            {
                return buildDatas[i];
            }

            return null;
        }
    }
    
    [Serializable]
    public class BuildData
    {
        public BuildingsType Type;
        public int WoodCost;
        public int StoneCost;
        public float BuildTime;
    }
}