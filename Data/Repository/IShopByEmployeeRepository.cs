using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IShopByEmployeeRepository
    {
            IQueryable<ShopByEmployee>? GetShopsByEmployee();

            ShopByEmployee GetShopsByEmployee(int id, DateTime workDate);

            bool ShopExists(int employeeId,DateTime workDate);

            bool CreateShopByEmployee(ShopByEmployee shopByEmployee);

            bool UpdateShop(ShopByEmployee shopByEmployee);

            bool DeleteShop(ShopByEmployee shopByEmployee);

            bool Save();
        
    }
}
