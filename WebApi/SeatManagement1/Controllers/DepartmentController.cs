using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
       
        public IActionResult GetDepartments([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var department = _departmentService.GetDepartment(id.Value);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            else
            {
                var departments = _departmentService.GetAllDepartment();
                return Ok(departments);
            }
        }


        [HttpPost]
        public IActionResult AddDepartment(DepartmentDTO departmentDTO)
        {
            int id = _departmentService.AddDepartment(departmentDTO);
            return Ok(id);
        }

       

        [HttpPut]
        public IActionResult EditDepartment(Department department)
        {
            _departmentService.EditDepartment(department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.DeleteDepartment(id);
            return Ok();
        }
    }

}
