using Data.Data;
using Data.Models;

namespace Data.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDBContext _appDBContext;
        public ShopRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public bool CreateShop(Shop shop)
        {
            _appDBContext.Shops.Add(shop);
            return Save();
        }

        public bool DeleteShop(Shop shop)
        {
            _appDBContext.Shops.Remove(shop);
            return Save();
        }

        public IQueryable<Shop> GetShops()
        {
            return _appDBContext.Shops.AsQueryable();

        }

        public bool Save()
        {
            return _appDBContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateShop(Shop shop)
        {
            _appDBContext.Shops.Update(shop);
            return Save();
        }

        public bool ShopExists(int id)
        {
            return _appDBContext.Employees.Any(x => x.Id == id);
        }

        public Shop GetShop(int id)
        {
            return _appDBContext.Shops.FirstOrDefault(x => x.Id == id);
        }

        public bool ShopExists(string name)
        {
            bool value = _appDBContext.Shops.Any(y => y.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

    }
}
