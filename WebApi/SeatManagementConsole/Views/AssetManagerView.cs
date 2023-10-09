using SeatManagement1.Models;
using SeatManagement1Console.Interfaces;
using SeatManagement1Console.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Views
{
    public class AssetManagerView
    {
        private readonly IEntityManager<Asset> assetManager;

        public AssetManagerView(IEntityManager<Asset> assetManager)
        {
            this.assetManager = assetManager;
        }
        public async Task<int> CreateOrAddExistingAssetView()
        {
            Console.WriteLine("1. Add  an existing asset");
            Console.WriteLine("2. Add  a new asset");
            Console.Write("Enter your option: ");
            var op3 = Convert.ToInt32(Console.ReadLine());
            int assetId = 0;

            if (op3 == 1)
            {
                var assetList = assetManager.GetAll().Result;
                foreach (var asset in assetList)
                {
                    Console.WriteLine($"{asset.AssetId}. {asset.AssetName}");
                }
                Console.Write("Enter the Asset Id of the asset you want: ");
                assetId = Convert.ToInt32(Console.ReadLine());

            }
            else if (op3 == 2)
            {
                Console.Write("Enter the name of the asset: ");
                var assetName = Console.ReadLine();
               

                var assetObj = new Asset
                {
                    AssetName = assetName,
                    
                };
                assetId = await assetManager.Add(assetObj);

            }
            return assetId;
        }
    }
    }

