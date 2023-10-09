using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly IMeetingRoomService _meetingRoomService;

        public MeetingRoomController(IMeetingRoomService meetingRoomService)
        {
            _meetingRoomService = meetingRoomService;
        }

      
        
        [HttpGet]
        
        public IActionResult GetMeetingRooms([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var meetingRoom = _meetingRoomService.GetMeetingRoom(id.Value);
                if (meetingRoom == null)
                {
                    return NotFound();
                }
                return Ok(meetingRoom);
            }
            else
            {
                var meetingRooms = _meetingRoomService.GetAllMeetingRoom();
                return Ok(meetingRooms);
            }
        }


        [HttpPut]
        public IActionResult EditMeetingRoom(MeetingRoom meetingRoom)
        {
            _meetingRoomService.EditMeetingRoom(meetingRoom);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeetingRoom(int id)
        {
            _meetingRoomService.DeleteMeetingRoom(id);
            return Ok();
        }
        [HttpPost]
     
        public IActionResult Add(int totalRooms, int FacilityId)
        {
            try
            {
              _meetingRoomService.AddBulkRooms(totalRooms, FacilityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
