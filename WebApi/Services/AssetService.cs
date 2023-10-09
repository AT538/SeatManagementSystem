using SeatManagement1.CustomExceptions;
using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class AssetService : IAssetService
    {
        private readonly IRepository<Asset> _asset;

        public AssetService(IRepository<Asset> asset)
        {
            _asset = asset;
        }

        public Asset[] GetAllAsset()
        {
            return _asset.GetAll();
        }

        public int AddAsset(AssetDTO assetDTO)
        {
            Asset asset = new Asset { AssetName = assetDTO.AssetName };
            _asset.Add(asset);
            return asset.AssetId;
        }

        public Asset GetAssetById(int id)
        {
            return _asset.GetById(id);
        }

        public void EditAsset(Asset asset)
        {
            var originalAsset = _asset.GetById(asset.AssetId);
            if (originalAsset == null)
            {
                throw new CustomException("Asset not found");
            }

            originalAsset.AssetName = asset.AssetName;
            _asset.Update(originalAsset);
        }

        public void DeleteAssetById(int id)
        {
            _asset.DeleteById(id);
        }
    }

}
