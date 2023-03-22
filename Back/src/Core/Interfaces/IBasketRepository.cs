using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Basket;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCliente> GetBasketAsync(string basketId);
        Task<BasketCliente> UpdateBasketAsync(BasketCliente basket);
        Task<bool> DeleteBasketAsync(string basketId);

    }
}