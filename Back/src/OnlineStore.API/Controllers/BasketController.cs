using Core.Interfaces;
using Core.Models.Basket;
using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<BasketCliente>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new BasketCliente(id));
        }

        [HttpPost]
        public async Task<ActionResult<BasketCliente>> UpdateBasket(BasketCliente basket)
        {
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);

            return Ok(updatedBasket);
        }

        [HttpDelete]
        public async Task<ActionResult<BasketCliente>> DeleteBasket(string id)
        {
            var DeleteBasket = await _basketRepository.DeleteBasketAsync(id);

            return Ok(DeleteBasket);
        }

    }
} 