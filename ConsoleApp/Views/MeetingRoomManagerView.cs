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
    public class MeetingRoomManagerView
    {
        private IEntityManager<MeetingRoom> meetingRoomManager;
        private readonly IEntityManager<MeetingRoomAssets> meetingRoomAssetsManager;

        public MeetingRoomManagerView(IEntityManager<MeetingRoom> meetingRoomManager, IEntityManager<MeetingRoomAssets> meetingRoomAssetsManager)
        {
            this.meetingRoomManager = meetingRoomManager;
            this.meetingRoomAssetsManager = meetingRoomAssetsManager;
        }

        public async Task AddBulkMeetingRoomView(int facilityId)
        {

            IEntityManager<MeetingRoomAssets> meetingRoomAssetsManager = new EntityManager<MeetingRoomAssets>("MeetingRoomAssets");
            IEntityManager<Asset> assetManager = new EntityManager<Asset>("Asset");
            AssetManagerView assetManagerView = new AssetManagerView(assetManager);
            int assetId;
            int meetingRoomId;

            Console.Write("How many number of Meeting Rooms does the facility have:");
            var totalMeetingRooms = Convert.ToInt32(Console.ReadLine());
            string extension = $"?FacilityId={facilityId}&totalRooms={totalMeetingRooms}";
            Console.WriteLine(extension);
             meetingRoomManager.AddMany(extension);
            Console.WriteLine("MeetingRoomAdded");
            Console.WriteLine("showing all meeting rooms");
           var meetingroom= await meetingRoomManager.GetAll();
            foreach (var item in meetingroom)
            {
                Console.WriteLine($"\n{item.MeetingRoomId}||{item.FacilityId} ");
            }
            int choice = 1;
            do
            {
                Console.WriteLine("Enter meeting room where you want to enter asset");
                meetingRoomId = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Showing all assets");
                Console.WriteLine("Which asset you want to add");
                var assetid = await assetManagerView.CreateOrAddExistingAssetView();

                Console.WriteLine(assetid);
                Console.WriteLine("enter quantity");
                var quantity = Int32.Parse(Console.ReadLine());
                MeetingRoomAssets asset = new MeetingRoomAssets
                {
                    MeetingRoomId = meetingRoomId,
                    AssetId = assetid,
                    quantity = quantity


                };
                await meetingRoomAssetsManager.Add(asset);
                Console.WriteLine("Enter 0 to stop adding and 1 to continue");

            } while (choice == 1);

        }
    }
}
