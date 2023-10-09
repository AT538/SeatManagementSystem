using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface IBuildingService
    {
        void DeleteBuildingById(int id);
        void EditBuilding(Building building);
        Building GetBuildingById(int id);
        int AddBuilding(BuildingDTO city);
        Building[] GetAllBuilding();

    }
}
