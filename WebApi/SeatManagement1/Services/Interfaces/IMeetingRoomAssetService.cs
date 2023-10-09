using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface IMeetingRoomAssetService
    {
        void DeleteMeetingRoomAsset(int id);
        void EditMeetingRoomAsset(MeetingRoomAssets meetingRoomAssetAllocation);
        MeetingRoomAssets GetMeetingRoomAsset(int id);
        int AddMeetingRoomAsset(MeetingRoomAssetsDTO meetingRoomAssetAllocation);
        MeetingRoomAssets[] GetAllMeetingRoomAsset();
    }
}
