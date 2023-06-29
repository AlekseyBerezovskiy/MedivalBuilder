using System;
using System.Collections.Generic;
using UnityEngine;

namespace MedivalBuilder.Task.Realization
{
    [CreateAssetMenu(fileName = "BuildTaskConfig", menuName = "Config/BuildTaskConfig")]
    public class BuildingsTaskConfig : ScriptableObject
    {
        [SerializeField] private List<BuildDataConfig> _buildings;

        private Dictionary<BuildingsType, BuildDataConfig> _buildDatas = new Dictionary<BuildingsType, BuildDataConfig>();
        
        [NonSerialized] private bool _isInited;

        public BuildData GetNextBuildingsLevelData(BuildingsType buildingsType)
        {
            if (!_isInited)
            {
                Init();  
            }

            if (_buildDatas.ContainsKey(buildingsType))
            {
                return _buildDatas[buildingsType].GetNextBuildingsLevelData();
            }

            return null;
        }

        private void Init()
        {
            for (int i = 0; i < _buildings.Count; i++)
            {
                if (!_buildDatas.ContainsKey(_buildings[i].BuildingsType))
                {
                    _buildDatas.Add(_buildings[i].BuildingsType, _buildings[i]);
                }
            }   
        }
    }

    public enum BuildingsType
    {
        WoodenStorage,
        StoneStorage
    }
}