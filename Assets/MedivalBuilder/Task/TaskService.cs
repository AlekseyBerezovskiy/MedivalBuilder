using System;
using MedivalBuilder.Inventory;
using MedivalBuilder.Task.Interfaces;
using Zenject;

namespace MedivalBuilder.Task
{
    public class TaskService : ITaskService, ITickable, IDisposable
    {
        private readonly TickableManager _tickableManager;

        public TaskService(TickableManager tickableManager)
        {
            _tickableManager = tickableManager;
            
            _tickableManager.Add(this);
        }
        
        public void CreatePickupItemTask(Item item)
        {
            
        }

        public void CreateBuildingsTask()
        {
            
        }

        public void Tick()
        {
            
        }

        public void Dispose()
        {
            _tickableManager.Remove(this);
        }
    }
}