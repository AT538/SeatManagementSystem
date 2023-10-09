using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Department[] GetAllDepartment()
        {
            return _departmentRepository.GetAll();
        }

        public int AddDepartment(DepartmentDTO departmentDTO)
        {
            Department department = new Department
            {
                DepartmentName = departmentDTO.DepartmentName
            };
            _departmentRepository.Add(department);
            return department.DepartmentId;
        }

        public Department GetDepartment(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public void EditDepartment(Department department)
        {
            var originalDepartment = _departmentRepository.GetById(department.DepartmentId);
            if (originalDepartment == null)
            {
                throw new Exception("Department not found");
            }

            originalDepartment.DepartmentName = department.DepartmentName;

            _departmentRepository.Update(originalDepartment);
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteById(id);
        }
    }

}
