using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    //[Authorize(Policy = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet]
      
        public IActionResult GetFacilities([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var facility = _facilityService.GetFacility(id.Value);
                if (facility == null)
                {
                    return NotFound();
                }
                return Ok(facility);
            }
            else
            {
                var facilities = _facilityService.GetAllFacility();
                return Ok(facilities);
            }
        }


        [HttpPost]
        public IActionResult AddFacility(FacilityDTO facilityDTO)
        {
            int id = _facilityService.AddFacility(facilityDTO);
            return Ok(id);
        }

        

        [HttpPut]
        public IActionResult EditFacility(Facility facility)
        {
            _facilityService.EditFacility(facility);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFacility(int id)
        {
            _facilityService.DeleteFacility(id);
            return Ok();
        }
    }

}
