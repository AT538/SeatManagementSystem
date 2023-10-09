using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee[] GetAllEmployee()
        {
            return _employeeRepository.GetAll();
        }

        public int AddEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                EmployeeName = employeeDTO.EmployeeName,
                IsAllocated = employeeDTO.IsAllocated,
                DepartmentId = employeeDTO.DepartmentId
            };
            _employeeRepository.Add(employee);
            return employee.EmployeeId;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void EditEmployee(Employee employee)
        {
            var originalEmployee = _employeeRepository.GetById(employee.EmployeeId);
            if (originalEmployee == null)
            {
                throw new Exception("Employee not found");
            }

            originalEmployee.EmployeeName = employee.EmployeeName;
            originalEmployee.IsAllocated = employee.IsAllocated;
            originalEmployee.DepartmentId = employee.DepartmentId;

            _employeeRepository.Update(originalEmployee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteById(id);
        }
    }

}
