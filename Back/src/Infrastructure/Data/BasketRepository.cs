using System.Text.Json;
using Core.Interfaces;
using Core.Models.Basket;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly StoreContext _context;
        public BasketRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            var basket = await _context.FindAsync<BasketCliente>(basketId);
            if (basket == null)
            return false;

            _context.Remove(basket);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BasketCliente> GetBasketAsync(string basketId)
        {
            var basket = await _context.Baskets.FindAsync(basketId);

            return basket == null ? null : basket; //Caso basket == null retorna null otherwise basket
        }

        public async Task<BasketCliente> UpdateBasketAsync(BasketCliente basket)
        {
            var existingBasket = await _context.Baskets.FindAsync(basket.Id);
            if (existingBasket != null)
        {
            _context.Baskets.Update(basket);
        }
        else
        {
            _context.Baskets.Add(basket);
        }
        await _context.SaveChangesAsync();

        return await GetBasketAsync(basket.Id);
        }
        
    }
}