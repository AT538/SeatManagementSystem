using SeatManagement1.Models;
using SeatManagement1Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Views
{
    internal class DepartmentManagerView
    {
        private readonly IEntityManager<Department> departmentManager;

        public DepartmentManagerView(IEntityManager<Department> departmentManager)
        {
            this.departmentManager = departmentManager;
        }

        public async Task<int> CreateOrAddExistingDepartmentView()
        {
            Console.WriteLine("1.Add to existing department\n2.Add to new department");
            Console.Write("Enter your option:");
            int op2 = Convert.ToInt32(Console.ReadLine());
            var departmentId = 0;
            if (op2 == 1)
            {
                var departmentList = departmentManager.GetAll().Result;
                foreach (var department in departmentList)
                {
                    Console.WriteLine($"{department.DepartmentId}. {department.DepartmentName}");
                }
                Console.Write("Enter the department Id of the deparment you want: ");
                departmentId = Convert.ToInt32(Console.ReadLine());

            }
            else if (op2 == 2)
            {
                Console.Write("Enter the name of Department: ");
                var deparmentName = Console.ReadLine();
                var department = new Department { DepartmentName = deparmentName };
                departmentId = await departmentManager.Add(department);
            }
            return departmentId;
        }
    }
}
