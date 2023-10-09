using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface IAssetService
    {
        void DeleteAssetById(int id);
        void EditAsset(Asset asset);
        Asset GetAssetById(int id);
        int AddAsset(AssetDTO asset);
        Asset[] GetAllAsset();
    }
}
