using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class MeetingRoomAssetService : IMeetingRoomAssetService
    {
        private readonly IRepository<MeetingRoomAssets> _meetingRoomAsset;

        public MeetingRoomAssetService(IRepository<MeetingRoomAssets> meetingRoomAsset)
        {
            _meetingRoomAsset = meetingRoomAsset;
        }

        public MeetingRoomAssets[] GetAllMeetingRoomAsset()
        {
            return _meetingRoomAsset.GetAll();
        }

        public int AddMeetingRoomAsset(MeetingRoomAssetsDTO assetDTO)
        {
            MeetingRoomAssets asset = new MeetingRoomAssets
            {
               MeetingRoomId= assetDTO.MeetingRoomId,
                AssetId = assetDTO.AssetId,
                quantity = assetDTO.quantity,
            };
            _meetingRoomAsset.Add(asset);
            return asset.MeetingRoomAssetId;
        }

        public MeetingRoomAssets GetMeetingRoomAsset(int id)
        {
            return _meetingRoomAsset.GetById(id);
        }

        public void EditMeetingRoomAsset(MeetingRoomAssets meetingRoomAsset)
        {
            var originalMeetingRoomAsset = _meetingRoomAsset.GetById(meetingRoomAsset.MeetingRoomAssetId);
            if (originalMeetingRoomAsset == null)
            {
                throw new Exception("MeetingRoomAssetAllocation not found");
            }

            originalMeetingRoomAsset.AssetId = meetingRoomAsset.AssetId;
            originalMeetingRoomAsset.quantity = meetingRoomAsset.quantity;

            _meetingRoomAsset.Update(originalMeetingRoomAsset);
        }

        public void DeleteMeetingRoomAsset(int id)
        {
            _meetingRoomAsset.DeleteById(id);
        }
    }

}
