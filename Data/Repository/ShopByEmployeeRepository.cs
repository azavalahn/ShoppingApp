using Data.Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ShopByEmployeeRepository : IShopByEmployeeRepository
    {
        private readonly AppDBContext _appDBContext;

        public ShopByEmployeeRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public bool CreateShopByEmployee(ShopByEmployee shopByEmployee)
        {
            _appDBContext.ShopsByEmployee.Add(shopByEmployee);
            return Save();
        }

        public bool DeleteShop(ShopByEmployee shopByEmployee)
        {
            _appDBContext.ShopsByEmployee.Remove(shopByEmployee);
            return Save();
        }

        public IQueryable<ShopByEmployee>? GetShopsByEmployee()
        {
            return _appDBContext.ShopsByEmployee.AsQueryable();
        }

        public ShopByEmployee GetShopsByEmployee(int id, DateTime workDate)
        {
            return _appDBContext.ShopsByEmployee.FirstOrDefault(s => s.EmployeeId == id && s.WorkDate.ToString("yyyyMMdd") == workDate.ToString("yyyyMMdd"));
        }

        public bool Save()
        {
            return _appDBContext.SaveChanges() >= 0 ? true : false;
        }

        public bool ShopExists(int employeeId, DateTime workDate)
        {
            bool value = _appDBContext.ShopsByEmployee.Any(y => y.EmployeeId == employeeId &&  y.WorkDate.ToString("yyyyMMdd") == workDate.ToString("yyyyMMdd"));
            return value;
        }


        public bool UpdateShop(ShopByEmployee shopByEmployee)
        {
            _appDBContext.ShopsByEmployee.Update(shopByEmployee);
            return Save();
        }
    }
}
