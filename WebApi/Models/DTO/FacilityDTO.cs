using SeatManagement1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement1.Models.DTO
{
    public class FacilityDTO
    {
        public string? FacilityName { get; set; }
        public int FloorNumber { get; set; }

        public int BuildingId { get; set; }



        public int CityId { get; set; }




    }
}
