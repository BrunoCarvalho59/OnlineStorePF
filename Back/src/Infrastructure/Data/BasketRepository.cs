using System.Text.Json;
using Core.Interfaces;
using Core.Models;
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
        var basket = await _context.Set<Baskets>().FindAsync(basketId);
        if (basket == null) return false;
        _context.Remove(basket);
        await _context.SaveChangesAsync();
        return true;
    }
 
    public async Task<BasketCliente> GetBasketAsync(string basketId)
    {
        var basket = await _context.Baskets.FirstOrDefaultAsync(p => p.Id == basketId);
        if (basket == null) return null;
        return JsonSerializer.Deserialize<BasketCliente>(basket.BasketData);
        }
 
    public async Task<BasketCliente> UpdateBasketAsync(BasketCliente basket)
    {
        if (basket == null) return null;
 
        var data = JsonSerializer.Serialize(basket);
        var existingBasket = await _context.Baskets.FirstOrDefaultAsync(p => p.Id == basket.Id);
        if (existingBasket == null) { // add new basket
        var newItem = new Baskets();
        newItem.Id = basket.Id;
        newItem.BasketData = data;
        newItem.lastUpdated = DateTime.Now;
        await _context.Baskets.AddAsync(newItem);
        await _context.SaveChangesAsync();
    } else { // update existing basket
        existingBasket.BasketData = data;
        existingBasket.lastUpdated = DateTime.Now;
        _context.Baskets.Update(existingBasket);
        await _context.SaveChangesAsync();
    }
        return basket;
    }
    }
    }