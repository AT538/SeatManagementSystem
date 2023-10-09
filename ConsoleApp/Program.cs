// See https://aka.ms/new-console-template for more information
using SeatManagement1.Models;
using SeatManagement1Console.Interfaces;
using SeatManagement1Console.Managers;
using SeatManagement1Console.Views;


class Program
{
    public static void Main(string[] args)
    {
        UI().Wait();
    }

  
    public static async Task UI()
    {
        IFacilityManager facilityManager = new FacilityManager("Facility");
        IEntityManager<Seat> seatManager = new EntityManager<Seat>("Seat");
        IEntityManager<CabinRoom> cabinManager = new EntityManager<CabinRoom>("CabinRoom");
        IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
        IEntityManager<MeetingRoom> meetingRoomManager = new EntityManager<MeetingRoom>("MeetingRoom");
        IEntityManager<MeetingRoomAssets> meetingRoomassetsManager = new EntityManager<MeetingRoomAssets>("MeetingRoomAssets");
        IEntityManager<Asset> assetManager = new EntityManager<Asset>("Asset");




        FacilityManagerView facilityManagerView = new FacilityManagerView(facilityManager);

        SeatManagerView seatManagerView = new SeatManagerView(seatManager);
        CabinManagerView cabinManagerView = new CabinManagerView(cabinManager);
        

        EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);

        MeetingRoomManagerView meetingRoomManagerView = new MeetingRoomManagerView(meetingRoomManager, meetingRoomassetsManager);
       AssetManagerView assetManagerView= new AssetManagerView(assetManager);






        Console.WriteLine("\t\tSEAT ALLOCATION SOFTWARE\t\t");
        Console.WriteLine("\n\n");

     
        
        do
        {


            
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("\n");
            Console.WriteLine("1.Onboard Facility\n2.Onboard Seats\n3.Add Employees\n4.Seat Allocation\n5.Seat Deallocation\n6.Cabin Allocation\n7.Cabin Deallocation\n8.Add Assets\n9.Free Seat Report\n10.Exit\n");
            
            Console.Write("Choose your option: ");
            int op1 = Convert.ToInt32(Console.ReadLine());
         

            switch (op1)
            {
                case 1:
                    {
                        await facilityManagerView.OnBoardFacilityView(facilityManagerView, seatManagerView, cabinManagerView, meetingRoomManagerView);
                        break;
                    }

                case 2:
                    {
                        await seatManagerView.OnBoardSeatsView(facilityManagerView, seatManagerView);
                        break;
                    }

                case 3:
                    {
                         employeeManagerView.CreateMultipleView();
                        break;
                    }

                case 4:
                    {
                        await seatManagerView.AllocateSeatView();
                        break;
                    }

                case 5:
                    {
                        await seatManagerView.DeAllocateSeatView();
                        break;
                    }

                case 6:
                    {
                        await cabinManagerView.AllocateCabinView();
                        break;
                    }

                case 7:
                    {
                        await cabinManagerView.DeAllocateCabinView();
                        break;
                    }

                case 8:
                    {
                        await assetManagerView.CreateOrAddExistingAssetView();
                        break;

                    }

                case 9:
                    {
                        await seatManagerView.FreeSeatView();
                        break;

                    }

                case 10:
                    {
                        System.Environment.Exit(0);
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Break");
                        break;
                    }


            }

         
            Console.WriteLine("\n\n\t\tGoing Back To Menu\n\n");
           

        } while (true);

    }
}


