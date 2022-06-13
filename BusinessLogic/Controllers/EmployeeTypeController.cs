using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Cors;

namespace Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeRepository _employeeTypeRepository;
        public EmployeeTypeController(IEmployeeTypeRepository employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        
        [HttpGet]

        public IQueryable Get()
        {
            return _employeeTypeRepository.GetEmployeeTypes();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeType employeeType)
        {
            if (employeeType == null)
                return BadRequest(ModelState);
            if ( _employeeTypeRepository.EmployeeTypeExists(employeeType.Name))
            {
                ModelState.AddModelError("", "Employee Type already Exist");
                return StatusCode(500, ModelState);
            }

            if (!_employeeTypeRepository.CreateEmployeeType(employeeType))
            {
                ModelState.AddModelError("", $"Something went wrong while saving employee type record of {employeeType.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok(employeeType);

        }

        [HttpPut("{employeeTypeId:int}")]
        public IActionResult Update(int employeeTypeId, [FromBody] EmployeeType employeeType)
        {
            if (employeeType == null || employeeTypeId != employeeType.Id)
                return BadRequest(ModelState);

            if (!_employeeTypeRepository.UpdateEmployeeType(employeeType))
            {
                ModelState.AddModelError("", $"Something went wrong while updating employee type : {employeeType.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{employeeTypeId:int}")]
        public IActionResult Delete(int employeeTypeId)
        {
            if (!_employeeTypeRepository.EmployeeTypeExists(employeeTypeId))
            {
                return NotFound();
            }

            var employeeTypeObj = _employeeTypeRepository.GetEmployeeType(employeeTypeId);

            if (!_employeeTypeRepository.DeleteEmployeeType(employeeTypeObj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting employee type : {employeeTypeObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
