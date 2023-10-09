using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public string? BuildingAbbreviation { get; set; }
    }
}
