using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using System.Collections;

namespace SeatManagement1.Services.Interfaces
{
    public interface ISeat
    {

        void DeleteSeatById(int id);
        void EditSeat(Seat seat);
        Seat GetSeatById(int id);
        int AddSeat(SeatDTO seatdto);
        Seat[] GetAllSeats();
        public void AddBulkSeats(int SeatCount, int FacilityId);
        public void AllocateSeat(int SeatId, int EmployeeId);
        public void DeAllocateSeat(int SeatId);
        IEnumerable GetFreeSeats(List<int>? cityid, List<int>? buildingid, List<int>? facilityid , List<int>? Floor,int? page, int? pageSize);

    }
}
