using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface ICabinRoomService
    {
        void DeleteCabinRoom(int id);
        void EditCabin(CabinRoom cabin);
        CabinRoom GetCabinRoomById(int id);
        int AddCabinRoom(CabinRoomDTO cabin);
        CabinRoom[] GetAllCabin();
        public void AddBulkCabins(int CabinCount, int FacilityId);
        public void AllocateCabin(int CabinRoomId, int EmployeeId);
        public void DeAllocateCabin(int CabinRoomId);

    }
}
