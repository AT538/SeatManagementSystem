using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class MeetingRoomAssets
    {
        [Key]
        public int MeetingRoomAssetId { get; set; }

        [ForeignKey("MeetingRoom")]
        public int MeetingRoomId { get; set; }
        public virtual MeetingRoom? MeetingRoom { get; set; }

        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public virtual Asset? Asset { get; set; }
        public int quantity { get; set; }
    }
}
