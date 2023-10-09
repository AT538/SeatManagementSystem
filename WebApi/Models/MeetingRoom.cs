using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class MeetingRoom
    {
        [Key]
        public int MeetingRoomId { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public virtual Facility? Facility { get; set; }
    }
}
