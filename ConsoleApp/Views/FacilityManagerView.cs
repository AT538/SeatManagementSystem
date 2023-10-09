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
    public class FacilityManagerView
    {
        private readonly IFacilityManager facilityManager;
        public FacilityManagerView(IFacilityManager facilityManager)
        {
            this.facilityManager = facilityManager;
        }

        public FacilityManagerView(IEntityManager<Facility> facilityManager1)
        {
        }

        public async Task<int> CreateFacilityView()
        {

            IEntityManager<City> cityManager = new EntityManager<City>("City");
            IEntityManager<Building> buildingManager = new EntityManager<Building>("Building");

            CityManagerView cityManagerView = new CityManagerView(cityManager);
            BuildingManagerView buildingManagerView = new BuildingManagerView(buildingManager);

            Console.WriteLine("Onboarding Facility");
            Console.WriteLine("Enter Details:");


            Console.WriteLine("Which City Does The Facility Belong To?");

            var cityId = await cityManagerView.CreateOrAddExistingCityView();

            Console.WriteLine("Which Building Does The Facility Belong To?");

            var buildingId = await buildingManagerView.CreateOrAddExistingBuildingView();

            Console.Write("Which Floor hosts the Facility: ");
            var floorNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("What Is The Name Of The Facility: ");
            var facilityName = Console.ReadLine();

            Facility facility = new Facility
            {
                FacilityName = facilityName,
                FloorNumber = floorNumber,
                BuildingId = buildingId,
                CityId = cityId,
            };

            return await facilityManager.OnBoardFacility(facility);
        }
        public async Task AllFacilitiesView()
        {
            IEntityManager<City> cityManager = new EntityManager<City>("City");
            IEntityManager<Building> buildingManager = new EntityManager<Building>("Building");

            await buildingManager.GetAll();
            await cityManager.GetAll();
            Console.WriteLine("List of all Facilities:");
            Console.WriteLine("\n| Facility ID | Facility Name | Facility Floor | City Name | Building Name |\n");
            var facilities = await facilityManager.GetAllFacilities();

            foreach (var facility in facilities)
            {
                Console.WriteLine($"\n| {facility.FacilityId} | {facility.FacilityName} | {facility.FloorNumber} | {facility.City.CityName} | {facility.Building.BuildingName} |\n");
            }
        }

        public async Task OnBoardFacilityView(FacilityManagerView facilityManagerView, SeatManagerView seatManagerView, CabinManagerView cabinManagerView, MeetingRoomManagerView meetingRoomManagerView)
        {
            int facilityId = await facilityManagerView.CreateFacilityView();
            seatManagerView.AddBulkSeatsView(facilityId);
            cabinManagerView.AddBulkCabinsView(facilityId);
            await meetingRoomManagerView.AddBulkMeetingRoomView(facilityId);
        }
    }
}
