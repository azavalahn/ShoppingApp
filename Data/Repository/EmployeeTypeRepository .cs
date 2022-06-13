using Data.Data;
using Data.Models;

namespace Data.Repository
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly AppDBContext _appDBContext;
        public EmployeeTypeRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public bool CreateEmployeeType(EmployeeType employeeType)
        {
            _appDBContext.EmployeeTypes?.Add(employeeType);
            return Save();
        }

        public bool DeleteEmployeeType(EmployeeType employeeType)
        {
            _appDBContext.EmployeeTypes?.Remove(employeeType);
            return Save();
        }

        public IQueryable<EmployeeType>? GetEmployeeTypes()
        {
            return _appDBContext.EmployeeTypes?.AsQueryable();

        }

        public bool Save()
        {
            return _appDBContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEmployeeType(EmployeeType employeeType)
        {
            _appDBContext.EmployeeTypes?.Update(employeeType);
            return Save();
        }

        public bool EmployeeTypeExists(int id)
        {
            return _appDBContext.EmployeeTypes.Any(x => x.Id == id);
        }

        public EmployeeType? GetEmployeeType(int id)
        {
            return _appDBContext.EmployeeTypes?.FirstOrDefault(x => x.Id == id);
        }

        public bool EmployeeTypeExists(string name)
        {
            bool value = _appDBContext.Employees.Any(y => y.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

    }
}
