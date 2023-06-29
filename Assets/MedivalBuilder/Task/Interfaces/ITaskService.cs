using MedivalBuilder.Inventory;

namespace MedivalBuilder.Task.Interfaces
{
    public interface ITaskService
    {
        void CreatePickupItemTask(Item item);
        void CreateBuildingsTask();
    }
}