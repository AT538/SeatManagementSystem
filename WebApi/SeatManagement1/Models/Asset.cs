using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
    }
}
