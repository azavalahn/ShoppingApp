using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Data.Models;
using Data.Repository;

namespace Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController: ControllerBase
    {
        private readonly IShopRepository _shopRepository;
        public ShopController(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        
        [HttpGet]

        public IQueryable Get()
        {
            return _shopRepository.GetShops();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shop shop)
        {
            if (shop == null)
                return BadRequest(ModelState);
            if (_shopRepository.ShopExists(shop.Name))
            {
                ModelState.AddModelError("", "Shop already Exist");
                return StatusCode(500, ModelState);
            }

            if (!_shopRepository.CreateShop(shop))
            {
                ModelState.AddModelError("", $"Something went wrong while saving shop record of {shop.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok(shop);

        }

        [HttpPut("{shopId:int}")]
        public IActionResult Update(int shopId, [FromBody] Shop shop)
        {
            if (shop == null || shopId != shop.Id)
                return BadRequest(ModelState);

            if (!_shopRepository.UpdateShop(shop))
            {
                ModelState.AddModelError("", $"Something went wrong while updating shop : {shop.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{shopId:int}")]
        public IActionResult Delete(int shopId)
        {
            if (!_shopRepository.ShopExists(shopId))
            {
                return NotFound();
            }

            var shopObj = _shopRepository.GetShop(shopId);

            if (!_shopRepository.DeleteShop(shopObj))
            {
                ModelState.AddModelError("", $"Something went wrong while deleting shop : {shopObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
