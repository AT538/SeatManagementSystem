using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _facilityRepository;

        public FacilityService(IRepository<Facility> facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public Facility[] GetAllFacility()
        {
            return _facilityRepository.GetAll();
        }

        public int AddFacility(FacilityDTO facilityDTO)
        {
            Facility facility = new Facility
            {
                FacilityName = facilityDTO.FacilityName,
                FloorNumber = facilityDTO.FloorNumber,
                BuildingId = facilityDTO.BuildingId,
                CityId = facilityDTO.CityId,
                
            };
            _facilityRepository.Add(facility);
            return facility.FacilityId;
        }

        public Facility GetFacility(int id)
        {
            return _facilityRepository.GetById(id);
        }

        public void EditFacility(Facility facility)
        {
            var originalFacility = _facilityRepository.GetById(facility.FacilityId);
            if (originalFacility == null)
            {
                throw new Exception("Facility not found");
            }

            originalFacility.FacilityName = facility.FacilityName;
            originalFacility.FloorNumber = facility.FloorNumber;
            originalFacility.BuildingId = facility.BuildingId;
            originalFacility.CityId = facility.CityId;
            

            _facilityRepository.Update(originalFacility);
        }

        public void DeleteFacility(int id)
        {
            _facilityRepository.DeleteById(id);
        }
    }

}
