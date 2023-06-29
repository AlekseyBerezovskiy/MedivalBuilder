using System;
using System.Collections.Generic;
using UnityEngine;

namespace MedivalBuilder.Task.Realization
{
    public class BuildDataConfig : ScriptableObject
    {
        public BuildingsType BuildingsType;

        [SerializeField] private List<BuildData> buildDatas;

        public BuildData GetNextBuildingsLevelData()
        {
            for (int i = 0; i < buildDatas.Count; i++)
            {
                if (!buildDatas[i].IsCreated)
                {
                    return buildDatas[i];
                }
            }

            return null;
        }
    }
    
    [Serializable]
    public class BuildData
    {
        public bool IsCreated;
        public int WoodCost;
        public int StoneCost;
        public float BuildTime;
    }
}