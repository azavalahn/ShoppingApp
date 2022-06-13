using BusinessLogic.Dtos;
using Data.Models;

namespace BusinessLogic
{
    public static class Extensions
    {
        public static EmployeeDto AsEmployeeDto( this Employee employee)
        {
            return new EmployeeDto
            {
                Name = employee.Name,
                EmployeeTypeId = employee.EmployeeTypeId,
                EmploymentDate = employee.EmploymentDate,
                Address = employee.Address,
                Telephone = employee.Telephone
            };

        }

        public static EmployeeTypeDto AsEmployeeTypeDto(this EmployeeType employeeType)
        {
            return new EmployeeTypeDto
            {
                Id = employeeType.Id,
                Name = employeeType.Name,

            };

        }

    }
}
