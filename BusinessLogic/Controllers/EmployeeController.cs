using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Data.Models;
using Data.Repository;
using BusinessLogic.Dtos;

namespace Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeTypeRepository = employeeTypeRepository;

        }


        [HttpGet]

        public IQueryable<EmployeeDisplayDto> Get()
        {
            var employees = _employeeRepository.GetEmployees();
            var employeeTypes = _employeeTypeRepository.GetEmployeeTypes();

            var employeeDisplayData = employees.Join(employeeTypes,
                employee => employee.EmployeeTypeId,
                employeeType => employeeType.Id,
                (employee, employeeTpe) => new EmployeeDisplayDto
                {
                    EmployeeName = employee.Name,
                    EmployeeTypeName = employeeTpe.Name,
                    Address = employee.Address,
                    EmploymentDate = employee.EmploymentDate,
                    Telephone = employee.Telephone
                });

            return employeeDisplayData;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest(ModelState);
            if (_employeeRepository.EmployeeExists(employee.Name))
            {
                ModelState.AddModelError("", "Employee Type already Exist");
                return StatusCode(500, ModelState);
            }

            if (!_employeeRepository.CreateEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong while saving employee type record of {employee.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok(employee);

        }

        [HttpPut("{employeeTypeId:int}")]
        public IActionResult Update(int employeeTypeId, [FromBody] Employee employee)
        {
            if (employee == null || employeeTypeId != employee.Id)
                return BadRequest(ModelState);

            if (!_employeeRepository.UpdateEmployee(employee))
            {
                ModelState.AddModelError("", $"Something went wrong while updating employee: {employee.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{employeeId:int}")]
        public IActionResult Delete(int employeeId)
        {
            if (!_employeeRepository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employeeObj = _employeeRepository.GetEmployee(employeeId);

            if (!_employeeRepository.DeleteEmployee(employeeObj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting employee : {employeeObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
