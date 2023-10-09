using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        
        public IActionResult GetBuildings([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var building = _buildingService.GetBuildingById(id.Value);
                if (building == null)
                {
                    return NotFound();
                }
                return Ok(building);
            }
            else
            {
                var buildings = _buildingService.GetAllBuilding();
                return Ok(buildings);
            }
        }


        [HttpPost]
        public IActionResult AddBuilding(BuildingDTO buildingDTO)
        {
            int id = _buildingService.AddBuilding(buildingDTO);
            return Ok(id);
        }

        

        [HttpPut]
        public IActionResult EditBuilding(Building building)
        {
            _buildingService.EditBuilding(building);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBuildingById(int id)
        {
            _buildingService.DeleteBuildingById(id);
            return Ok();
        }
    }

}
