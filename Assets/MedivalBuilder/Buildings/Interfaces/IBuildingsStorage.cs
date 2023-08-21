using MedivalBuilder.Task.Realization;

namespace MedivalBuilder.Buildings.Interfaces
{
    public interface IBuildingsStorage
    {
        BuildingController GetBuilding(BuildingsType type);
    }
}