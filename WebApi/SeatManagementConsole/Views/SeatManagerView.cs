using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
    public class SeatManagerView
    {
        IEntityManager<Seat> seatManager;
        public SeatManagerView(IEntityManager<Seat> seatManager)
        {
            this.seatManager = seatManager;
        }

        public async void AddBulkSeatsView(int facilityId)
        {

            Console.Write("How many number of seats does the facility require: ");
            var totalSeats = Convert.ToInt32(Console.ReadLine());

            string extension = $"?FacilityId={facilityId}&totalSeats={totalSeats}";
            try
            {
                seatManager.AddMany(extension);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task AllocateSeatView()
        {

            IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
            EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);


            await employeeManagerView.ListUnAllocatedEmployeesView();

            Console.Write("Enter An Employee Id: ");
            var empId = Convert.ToInt32(Console.ReadLine());



            Console.Write("Enter A Seat Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.Allocate(entityId, empId);
        }

        public async Task DeAllocateSeatView()
        {


            Console.Write("Enter A Seat Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<Seat> SeatAllocater = new AllocationManager<Seat>("Seat");

            SeatAllocater.DeAllocate(entityId);
        }

        public async Task OnBoardSeatsView(FacilityManagerView facilityManagerView, SeatManagerView seatManagerView)
        {
            await facilityManagerView.AllFacilitiesView();

            Console.Write("Enter a Facility Where You Wish To Onboard Seats: ");
            int facilityId = Convert.ToInt32(Console.ReadLine());

            seatManagerView.AddBulkSeatsView(facilityId);
        }

        public async Task FreeSeatView()
        {
            int choice = 0;
            int? id = null;
            List<int?> cityid = new List<int?>();
            List<int?> buildingid = new List<int?>();
            List<int?> floorid = new List<int?>();
            List<int?> facilityid = new List<int?>();
            string? page = null;
            string? pagesize = null;

            string cityIdQueryString = null;
            string buildingIdQueryString = null;
            string floorIdQueryString = null;
            string facilityIdQueryString = null;
            int loop = 1;
            string query = "?";

            do
            {
                Console.WriteLine("Choose any option accordingly how you want to filter");
                Console.WriteLine("\n 1. Get all free seats");
                Console.WriteLine("\n 2. Filter by city id");
                Console.WriteLine("\n 3. Filter by building id");
                Console.WriteLine("\n 4. Filter by floor id");
                Console.WriteLine("\n 5. Filter by facility id");
                Console.WriteLine("\n 6. Paginate");
                Console.WriteLine("Enter your choice");
                choice = Int32.Parse(Console.ReadLine());
             
                switch (choice)
                {
                    case 1:
                        {
                            string _extension = null;
                            var _freeseats = await seatManager.GetAllWithExtension(_extension);
                            foreach(var seat in _freeseats) { Console.WriteLine($"\n| {seat.SeatId} | {seat.FacilityId} |{seat.Facility.FacilityName}"); }
                            
                            break;

                        }
                    case 2:
                        {

                            do
                            {
                                Console.WriteLine("\nEnter city ids ");
                                string cityId = Console.ReadLine();
                                query += $"cityid={cityId}&";
                                Console.WriteLine("enter 0 to stop and 1 to continue");
                                id = Int32.Parse(Console.ReadLine());
                            } while (id != 0);

                            break;
                        }
                    case 3:
                        {
                            do
                            {
                                Console.WriteLine("\nEnter building ids ");
                                string buildingId = Console.ReadLine();
                                query += $"buildingid={buildingId}&";
                                Console.WriteLine("enter 0 to stop and 1 to continue");
                                id = Int32.Parse(Console.ReadLine());
                            } while (id != 0);

                            break;
                        }
                    case 4:
                        {
                            do
                            {
                                Console.WriteLine("\nEnter floor ids ");
                                string floorId = Console.ReadLine();
                                query += $"floorid={floorId}&";
                                Console.WriteLine("enter 0 to stop and 1 to continue");
                                id = Int32.Parse(Console.ReadLine());
                            } while (id != 0);
                            break;
                        }
                    case 5:
                        {
                            do
                            {
                                Console.WriteLine("\nEnter facility ids ");
                                string facilityId = Console.ReadLine();
                                query += $"facilityid={facilityId}&";
                                Console.WriteLine("enter 0 to stop and 1 to continue");
                                id = Int32.Parse(Console.ReadLine());
                            } while (id != 0);
                            break;
                        }
                    case 6:
                        Console.WriteLine("Enter the page you want to display");
                        page =Console.ReadLine();
                        Console.WriteLine("Enter page size");
                        pagesize = Console.ReadLine();
                        break;
                    
                    default:break;
                        
                }

                Console.WriteLine("Enter 1 to continue filtering and 0 to stop");
                loop = Int32.Parse(Console.ReadLine());
            } while (loop == 1);
          
            if (page != null)
            {
                query += $"page={page}";
            }

            if (pagesize != null)
            {
                query += $"&pageSize={pagesize}";
            }



                Console.WriteLine(query);
                    var freeseats = await seatManager.GetAllWithExtension(query);

                    foreach (var freeseat in freeseats)
                    {
                        Console.WriteLine($"\n| {freeseat.SeatId} | {freeseat.FacilityId} |{freeseat.Facility.FacilityName}");
                    }
                }


            }
        }
    

