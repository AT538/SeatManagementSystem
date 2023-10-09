using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
       
        public IActionResult GetEmployees([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var employee = _employeeService.GetEmployee(id.Value);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            else
            {
                var employees = _employeeService.GetAllEmployee();
                return Ok(employees);
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO employeeDTO)
        {
            int id = _employeeService.AddEmployee(employeeDTO);
            return Ok(id);
        }


        [HttpPut]
        public IActionResult EditEmployee(Employee employee)
        {
            _employeeService.EditEmployee(employee);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }

}
