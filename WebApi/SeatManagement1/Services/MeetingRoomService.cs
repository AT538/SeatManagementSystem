using SeatManagement1.CustomExceptions;
using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public MeetingRoomService(IRepository<MeetingRoom> meetingRoomRepository, IRepository<Facility> facilityRepository)
        {
            _meetingRoomRepository = meetingRoomRepository;
            _facilityRepository = facilityRepository;
        }

        public MeetingRoom[] GetAllMeetingRoom()
        {
            return _meetingRoomRepository.GetAll();
        }

        public int AddMeetingRoom(MeetingRoomDTO meetingRoomDTO)
        {
            MeetingRoom meetingRoom = new MeetingRoom
            {
                FacilityId = meetingRoomDTO.FacilityId
            };
            _meetingRoomRepository.Add(meetingRoom);
            return meetingRoom.MeetingRoomId;
        }

        public MeetingRoom GetMeetingRoom(int id)
        {
            return _meetingRoomRepository.GetById(id);
        }

        public void EditMeetingRoom(MeetingRoom meetingRoom)
        {
            var originalMeetingRoom = _meetingRoomRepository.GetById(meetingRoom.MeetingRoomId);
            if (originalMeetingRoom == null)
            {
                throw new Exception("MeetingRoom not found");
            }

            originalMeetingRoom.FacilityId = meetingRoom.FacilityId;

            _meetingRoomRepository.Update(originalMeetingRoom);
        }

        public void DeleteMeetingRoom(int id)
        {
            _meetingRoomRepository.DeleteById(id);
        }
        public void AddBulkRooms(int RoomCount, int FacilityId)
        {


            List<MeetingRoom> emptyRooms = new List<MeetingRoom>();
            if (_facilityRepository.GetById(FacilityId) == null)
            {
                throw new CustomException("Facility doesn't exist");
            }
            int Count = _meetingRoomRepository.GetAll().Where(x => x.FacilityId == FacilityId).Count();
            for (int i = 0; i < RoomCount; i++)
            {

                MeetingRoom emptyRoom = new MeetingRoom
                {
                    FacilityId = FacilityId

                };
                emptyRooms.Add(emptyRoom);
            }

           _meetingRoomRepository.AddMany(emptyRooms);

        }
    }

}
