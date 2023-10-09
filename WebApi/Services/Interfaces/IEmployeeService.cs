using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface IEmployeeService
    {
        void DeleteEmployee(int id);
        void EditEmployee(Employee employee);
        Employee GetEmployee(int id);
        int AddEmployee(EmployeeDTO employee);
        Employee[] GetAllEmployee();
    }
}
