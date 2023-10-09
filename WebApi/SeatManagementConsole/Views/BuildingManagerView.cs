using SeatManagement1.Models;
using SeatManagement1Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Views
{
    public class BuildingManagerView
    {
       private readonly IEntityManager<Building> buildingManager;
        public BuildingManagerView(IEntityManager<Building> buildingManager)
        {
            this.buildingManager = buildingManager;
        }

        public async Task<int> CreateOrAddExistingBuildingView()
        {
            Console.WriteLine("1. Add to an existing building");
            Console.WriteLine("2. Add to a new building");
            Console.Write("Enter your option: ");
            var op3 = Convert.ToInt32(Console.ReadLine());
            int buildingId = 0;

            if (op3 == 1)
            {
                var buildingList =  buildingManager.GetAll().Result;
                foreach (var building in buildingList)
                {
                    Console.WriteLine($"{building.BuildingId}. {building.BuildingName}");
                }
                Console.Write("Enter the Building Id of the building you want: ");
                buildingId = Convert.ToInt32(Console.ReadLine());

            }
            else if (op3 == 2)
            {
                Console.Write("Enter the name of the building: ");
                var buildingName = Console.ReadLine();
                Console.Write("Enter a building abbreviation: ");
                var buildingAbbreviation = Console.ReadLine();

                var buildingObj = new Building
                {
                    BuildingName = buildingName,
                    BuildingAbbreviation = buildingAbbreviation
                };
                buildingId = await buildingManager.Add(buildingObj);

            }
            return buildingId;
        }
    }
}
