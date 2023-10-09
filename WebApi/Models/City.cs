using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? CityAbbreviation { get; set; }
    }
}
