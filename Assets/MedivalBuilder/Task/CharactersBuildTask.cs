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
        private readonly IItemsStorage _itemsStorage;

        private int _iterator;
        private BuildAction _currentBuildAction;

        public CharactersBuildTask(
            BuildData buildData, 
            CharacterController characterController,
            IItemsStorage itemsStorage,
            IBuildingsStorage buildingsStorage)
        {
            _characterController = characterController;
            _itemsStorage = itemsStorage;

            Actions = new Queue<BuildAction>();
            
            var building = buildingsStorage.GetBuilding(buildData.Type);

            for (int i = 0; i < buildData.WoodCost; i++)
            {
                Actions.Enqueue(new BuildAction(
                    ItemType.Wood, 
                    building.BuildingView.transform));
            }
            
            for (int i = 0; i < buildData.StoneCost; i++)
            {
                Actions.Enqueue(new BuildAction(
                    ItemType.Stone, 
                    building.BuildingView.transform));
            }
            
            Actions.Enqueue(new BuildAction(buildData.BuildTime));

            _currentBuildAction = Actions.Dequeue();
            StartTask();
        }

        private void StartTask()
        {
            if (_iterator >= _currentBuildAction.DoList.Count)
            {
                if (Actions.Count == 0)
                {
                    return;
                }
                
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
                    _characterController.SetIdle();
                    break;
                case CharacterStateType.Walk:
                    var target = _currentBuildAction.DoList[_iterator].DoData as Transform;
                    
                    if (target == null)
                    {
                        var itemType = (ItemType) _currentBuildAction.DoList[_iterator].DoData;
                        target = _itemsStorage.Get(itemType, false).ItemView.transform;
                    }
                    
                    _characterController.SetWalk(target, endCallback);
                    break;
                case CharacterStateType.Pickup:
                    var itemTypeForPickup = (ItemType)_currentBuildAction.DoList[_iterator].DoData;
                    
                    _characterController.SetPickup( 
                        _itemsStorage.Get(itemTypeForPickup, true), 
                        endCallback);
                    break;
                case CharacterStateType.Build:
                    var time = (float) _currentBuildAction.DoList[_iterator].DoData;
                    _characterController.SetBuild(time, endCallback);
                    break;
                case CharacterStateType.Put:
                    _characterController.SetPut(endCallback);
                    break;
            }
        }
    }

    public class BuildAction
    {
        public List<CharacterDo> DoList = new List<CharacterDo>();

        public BuildAction(ItemType itemType, Transform target)
        {
            DoList.Add(new CharacterDo(CharacterStateType.Walk, itemType));
            DoList.Add(new CharacterDo(CharacterStateType.Pickup, itemType));
            DoList.Add(new CharacterDo(CharacterStateType.Walk, target));
            DoList.Add(new CharacterDo(CharacterStateType.Put, null));
        }
        
        public BuildAction(float timeToBuild)
        {
            DoList.Add(new CharacterDo(CharacterStateType.Build, timeToBuild));
            DoList.Add(new CharacterDo(CharacterStateType.Idle, null));
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