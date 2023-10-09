using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;
using System.Collections.Generic;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinRoomController : ControllerBase
    {
        private readonly ICabinRoomService _cabinRoomService;

        public CabinRoomController(ICabinRoomService cabinRoomService)
        {
            _cabinRoomService = cabinRoomService;
        }
        [HttpGet]
      
        public IActionResult GetCabinRooms([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var cabinRoom = _cabinRoomService.GetCabinRoomById(id.Value);
                if (cabinRoom == null)
                {
                    return NotFound();
                }
                return Ok(cabinRoom);
            }
            else
            {
                var cabinRooms = _cabinRoomService.GetAllCabin();
                return Ok(cabinRooms);
            }
        }






       

        [HttpDelete("{id}")]
        public IActionResult DeleteCabinRoom(int id)
        {
            _cabinRoomService.DeleteCabinRoom(id);
            return Ok();
        }

        [HttpPatch]
       
        public IActionResult Allocate(int id, int EmployeeId)
        {
            if (EmployeeId == 0)
                _cabinRoomService.DeAllocateCabin(id);
            else
                _cabinRoomService.AllocateCabin(id, EmployeeId);
            return Ok();
        }
        [HttpPost]
        public IActionResult Add(int totalCabins, int FacilityId)
        {
            try
            {
                _cabinRoomService.AddBulkCabins(totalCabins, FacilityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
