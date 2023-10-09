using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface IDepartmentService
    {
        void DeleteDepartment(int id);
        void EditDepartment(Department department);
        Department GetDepartment(int id);
        int AddDepartment(DepartmentDTO department);
        Department[] GetAllDepartment();
    }
}
