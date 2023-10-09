using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface IFacilityService
    {
        void DeleteFacility(int id);
        void EditFacility(Facility facility);
        Facility GetFacility(int id);
        int AddFacility(FacilityDTO facility);
        Facility[] GetAllFacility();
    }
}
