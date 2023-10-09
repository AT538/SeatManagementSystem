using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class CabinRoom
    {
        [Key]
        public int CabinRoomId { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public virtual Facility? Facility { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }


    }
}
