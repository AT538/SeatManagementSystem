using Microsoft.AspNetCore.Mvc;
using SeatManagement1.CustomExceptions;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services;
using SeatManagement1.Services.Interfaces;



namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeat _seat;


        public SeatController(ISeat seat)
        {
            _seat = seat;

        }


        [HttpPut]
        public IActionResult EditSeat(Seat seat)
        {
            _seat.EditSeat(seat);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeatById(int id)
        {
            _seat.DeleteSeatById(id);
            return Ok();
        }
        [HttpPatch]
       
        public IActionResult Allocate(int id, int EmployeeId)
        {
            if (EmployeeId == 0)
                _seat.DeAllocateSeat(id);
            else
                _seat.AllocateSeat(id, EmployeeId);
            return Ok();
        }
        [HttpPost]

        public IActionResult Add(int totalSeats, int FacilityId)
        {
            try
            {
                _seat.AddBulkSeats(totalSeats, FacilityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


       

        [HttpGet]
       
        public IActionResult GetSeats(
    [FromQuery] int? id,
    [FromQuery] List<int>? cityid,
    [FromQuery] List<int>? buildingid,
    [FromQuery] List<int>? facilityid,
    [FromQuery] List<int>? Floor,
    [FromQuery] int? page,
    [FromQuery] int? pageSize)
        {
            if (id.HasValue)
            {
                var seat = _seat.GetSeatById(id.Value);
                if (seat == null)
                {
                    throw new CustomException("Seat not found");
                }
                return Ok(seat);
            }
            else if (cityid != null || buildingid != null || facilityid != null ||Floor!=null|| page.HasValue || pageSize.HasValue)
            {
                var seats = _seat.GetFreeSeats(cityid, buildingid, facilityid,Floor, page, pageSize);
                return Ok(seats);
            }
            else
            {
                var seats = _seat.GetAllSeats();
                return Ok(seats);
            }
        }



    }
}

