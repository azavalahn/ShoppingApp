using Data.Models;

namespace Data.Repository
{
        public interface IEmployeeTypeRepository
        {
            IQueryable<EmployeeType>? GetEmployeeTypes();

            EmployeeType? GetEmployeeType(int id);

            bool EmployeeTypeExists(int id);

            bool EmployeeTypeExists(string name);

            bool CreateEmployeeType(EmployeeType employeeType);

            bool UpdateEmployeeType(EmployeeType employeeType);

            bool DeleteEmployeeType(EmployeeType employeeType);

            bool Save();
        }
    
}
