using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRoomAssetsController : ControllerBase
    {
        private readonly IMeetingRoomAssetService _meetingRoomAssetService;

        public MeetingRoomAssetsController(IMeetingRoomAssetService meetingRoomAssetService)
        {
            _meetingRoomAssetService = meetingRoomAssetService;
        }

        [HttpGet]
        
        public IActionResult GetMeetingRoomAssets([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var meetingRoomAsset = _meetingRoomAssetService.GetMeetingRoomAsset(id.Value);
                if (meetingRoomAsset == null)
                {
                    return NotFound();
                }
                return Ok(meetingRoomAsset);
            }
            else
            {
                var meetingRoomAssets = _meetingRoomAssetService.GetAllMeetingRoomAsset();
                return Ok(meetingRoomAssets);
            }
        }


        [HttpPost]
        public IActionResult AddMeetingRoomAsset(MeetingRoomAssetsDTO assetDTO)
        {
            int id = _meetingRoomAssetService.AddMeetingRoomAsset(assetDTO);
            return Ok(id);
        }



        [HttpPut]
        public IActionResult EditMeetingRoomAsset(MeetingRoomAssets meetingRoomAsset)
        {
            _meetingRoomAssetService.EditMeetingRoomAsset(meetingRoomAsset);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeetingRoomAsset(int id)
        {
            _meetingRoomAssetService.DeleteMeetingRoomAsset(id);
            return Ok();
        }
    }

}
