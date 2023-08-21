using System;
using System.Collections.Generic;
using MedivalBuilder.Buildings.Interfaces;
using MedivalBuilder.Characters.StateMachine;
using MedivalBuilder.Inventory;
using MedivalBuilder.Inventory.Interfaces;
using MedivalBuilder.Task.Realization;
using UnityEngine;
using CharacterController = MedivalBuilder.Characters.CharacterController;

namespace MedivalBuilder.Task
{
    public class CharactersBuildTask
    {
        public event Action OnDoneBuildingTaskEvent;
        public Queue<BuildAction> Actions { get; }
        
        private readonly CharacterController _characterController;

        private int _iterator;
        private BuildAction _currentBuildAction;

        public CharactersBuildTask(
            BuildData buildData, 
            CharacterController characterController,
            IItemsStorage itemsStorage,
            IBuildingsStorage buildingsStorage)
        {
            _characterController = characterController;
            
            Actions = new Queue<BuildAction>();

            var woodItem = itemsStorage.Get(ItemType.Wood);
            var stoneItem = itemsStorage.Get(ItemType.Stone);
            
            var building = buildingsStorage.GetBuilding(buildData.Type);

            for (int i = 0; i < buildData.WoodCost; i++)
            {
                Actions.Enqueue(new BuildAction(woodItem, building.BuildingView.transform, buildData.BuildTime));
            }
            
            for (int i = 0; i < buildData.StoneCost; i++)
            {
                Actions.Enqueue(new BuildAction(stoneItem, building.BuildingView.transform, buildData.BuildTime));
            }

            _currentBuildAction = Actions.Dequeue();
            StartTask();
        }

        private void StartTask()
        {
            if (_iterator > _currentBuildAction.DoList.Count)
            {
                _currentBuildAction = Actions.Dequeue();
                _iterator = 0;
            }
            
            Action endCallback = () =>
            {
                _iterator++;
                StartTask();
            };

            switch (_currentBuildAction.DoList[_iterator].CharacterStateType)
            {
                case CharacterStateType.Idle:
                    break;
                case CharacterStateType.Walk:
                    var target = (Transform)_currentBuildAction.DoList[_iterator].DoData;
                    _characterController.SetWalk(target.position, endCallback);
                    break;
                case CharacterStateType.Pickup:
                    var item = (Item)_currentBuildAction.DoList[_iterator].DoData;
                    _characterController.SetPickup(item, endCallback);
                    break;
                case CharacterStateType.Build:
                    var time = (float) _currentBuildAction.DoList[_iterator].DoData;
                    _characterController.SetBuild(time, endCallback);
                    break;
            }
        }
    }

    public class BuildAction
    {
        public List<CharacterDo> DoList = new List<CharacterDo>();

        public BuildAction(Item item, Transform target, float timeToBuild)
        {
            DoList.Add(new CharacterDo(CharacterStateType.Walk, item.ItemView.transform));
            DoList.Add(new CharacterDo(CharacterStateType.Pickup, item));
            DoList.Add(new CharacterDo(CharacterStateType.Walk, target));
            DoList.Add(new CharacterDo(CharacterStateType.Build, timeToBuild));
        }
    }

    public class CharacterDo
    {
        public CharacterStateType CharacterStateType { get; }
        public object DoData { get; }

        public CharacterDo(CharacterStateType characterStateType ,object doData)
        {
            CharacterStateType = characterStateType;
            DoData = doData;
        }
    }
}