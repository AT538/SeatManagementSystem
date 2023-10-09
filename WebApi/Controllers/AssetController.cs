using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SeatManagement1.CustomExceptions;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;
using System;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }
        [HttpGet]
        public IActionResult GetAssetById([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var asset = _assetService.GetAssetById((int)id);
                if (asset == null)
                {
                    throw new CustomException("Asset not found");
                }
                return Ok(asset);
            }
            else
            {
                var asset = _assetService.GetAllAsset();
                return Ok(asset);
            }
        }

        [HttpPost]
        public IActionResult AddAsset(AssetDTO assetDTO)
        {
            int id = _assetService.AddAsset(assetDTO);
            return Ok(id);
        }

        
        

        [HttpPut]
        public IActionResult EditAsset(Asset asset)
        {
            _assetService.EditAsset(asset);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAssetById(int id)
        {
            _assetService.DeleteAssetById(id);
            return Ok();
        }
    }

}
