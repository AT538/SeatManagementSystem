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
    public class CabinManagerView
    {
        private readonly IEntityManager<CabinRoom> cabinManager;

        public CabinManagerView(IEntityManager<CabinRoom> cabinManager)
        {
            this.cabinManager = cabinManager;
        }

        public async void AddBulkCabinsView(int facilityId)
        {
            Console.Write("How many number of cabins does the facility have:");
            var totalCabins = Convert.ToInt32(Console.ReadLine());
            string extension = $"?FacilityId={facilityId}&totalCabins={totalCabins}";
            cabinManager.AddMany(extension);
        }

        public async Task AllocateCabinView()
        {
            IEntityManager<Employee> employeeManager = new EntityManager<Employee>("Employee");
            EmployeeManagerView employeeManagerView = new EmployeeManagerView(employeeManager);


            await employeeManagerView.ListUnAllocatedEmployeesView();

            Console.Write("Enter An Employee Id: ");
            var empId = Convert.ToInt32(Console.ReadLine());


          

            Console.Write("Enter A Cabin Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<CabinRoom> CabinAllocater = new AllocationManager<CabinRoom>("Cabin");

            CabinAllocater.Allocate(entityId, empId);
        }

        public async Task DeAllocateCabinView()
        {
            
           

            Console.Write("Enter A Cabin Id: ");
            var entityId = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<CabinRoom> CabinAllocater = new AllocationManager<CabinRoom>("Cabin");

            CabinAllocater.DeAllocate(entityId);
        }

        
    }
}
