using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<Building> _buildingRepository;

        public BuildingService(IRepository<Building> buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public Building[] GetAllBuilding()
        {
            return _buildingRepository.GetAll();
        }

        public int AddBuilding(BuildingDTO buildingDTO)
        {
            Building building = new Building
            {
                BuildingName = buildingDTO.BuildingName,
                BuildingAbbreviation = buildingDTO.BuildingAbbreviation
            };
            _buildingRepository.Add(building);
            return building.BuildingId;
        }

        public Building GetBuildingById(int id)
        {
            return _buildingRepository.GetById(id);
        }

        public void EditBuilding(Building building)
        {
            var originalBuilding = _buildingRepository.GetById(building.BuildingId);
            if (originalBuilding == null)
            {
                throw new Exception("Building not found");
            }

            originalBuilding.BuildingName = building.BuildingName;
            originalBuilding.BuildingAbbreviation = building.BuildingAbbreviation;

            _buildingRepository.Update(originalBuilding);
        }

        public void DeleteBuildingById(int id)
        {
            _buildingRepository.DeleteById(id);
        }
    }

}
