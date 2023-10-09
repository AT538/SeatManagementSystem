using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement1.Models.DTO
{
    public class EmployeeDTO
    {
        public string? EmployeeName { get; set; }
        public bool IsAllocated { get; set; }

        public int DepartmentId { get; set; }
    }
}
