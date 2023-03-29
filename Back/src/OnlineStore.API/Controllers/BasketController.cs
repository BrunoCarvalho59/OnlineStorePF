using AutoMapper;
using Core.Interfaces;
using Core.Models.Basket;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<BasketCliente>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new BasketCliente(id));
        }

        [HttpPost]
        public async Task<ActionResult<BasketCliente>> UpdateBasket(BasketClienteDto basket)
        {
            var basketCliente = _mapper.Map<BasketClienteDto, BasketCliente>(basket);
            
            var updatedBasket = await _basketRepository.UpdateBasketAsync(basketCliente);

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