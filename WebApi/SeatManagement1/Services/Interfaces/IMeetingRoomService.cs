using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services;

namespace SeatManagement1.Services.Interfaces
{
    public interface IMeetingRoomService
    {
        void DeleteMeetingRoom(int id);
        void EditMeetingRoom(MeetingRoom meetingRoom);
        MeetingRoom GetMeetingRoom(int id);
        int AddMeetingRoom(MeetingRoomDTO meetingRoom);
        MeetingRoom[] GetAllMeetingRoom();
        public void AddBulkRooms(int RoomCount, int FacilityId);
    }
}
