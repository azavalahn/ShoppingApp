using Data.Models;

namespace Data.Repository
{
    public interface IShopRepository
    {
            IQueryable<Shop>? GetShops();

            Shop GetShop(int id);

            bool ShopExists(int id);

            bool ShopExists(string name);

            bool CreateShop(Shop shop);

            bool UpdateShop(Shop shop);

            bool DeleteShop(Shop shop);

            bool Save();
     }
   
}
