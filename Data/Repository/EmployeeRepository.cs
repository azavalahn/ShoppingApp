using Data.Data;
using Data.Models;

namespace Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext _appDBContext;
        public EmployeeRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public bool CreateEmployee(Employee employee)
        {
            _appDBContext.Employees?.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _appDBContext.Employees?.Remove(employee);
            return Save();
        }

        public IQueryable<Employee>? GetEmployees()
        {
            return _appDBContext.Employees?.AsQueryable();

        }

        public bool Save()
        {
            return _appDBContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _appDBContext.Employees?.Update(employee);
            return Save();
        }

        public bool EmployeeExists(int id)
        {
            return _appDBContext.Employees.Any(x => x.Id == id);
        }

        public Employee GetEmployee(int id)
        {
            return _appDBContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public bool EmployeeExists(string name)
        {
            bool value = _appDBContext.Employees.Any(y => y.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

    }
}
