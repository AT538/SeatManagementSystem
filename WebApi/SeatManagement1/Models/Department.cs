using System.ComponentModel.DataAnnotations;

namespace SeatManagement1.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
