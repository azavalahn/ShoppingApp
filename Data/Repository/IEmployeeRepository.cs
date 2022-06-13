using Data.Models;

namespace Data.Repository
{
    public interface IEmployeeRepository
    {
            IQueryable<Employee>? GetEmployees();

            Employee GetEmployee(int id);

            bool EmployeeExists(int id);

            bool EmployeeExists(string name);

            bool CreateEmployee(Employee employee);

            bool UpdateEmployee(Employee employee);

            bool DeleteEmployee(Employee employee);

            bool Save();
     }
   
}
