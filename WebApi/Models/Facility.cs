using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }
        public string? FacilityName { get; set; }
        public int FloorNumber { get; set; }
        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public virtual Building? Building { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City? City { get; set; }
       


    }
}
