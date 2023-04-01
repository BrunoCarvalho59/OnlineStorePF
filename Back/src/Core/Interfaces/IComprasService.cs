using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Compras;

namespace Core.Interfaces
{
    public interface IComprasService
    {
        Task<Compra> CreateCompraAsync(string clienteEmail, int metodoEnvio, string basketId, Morada moradaEnvio);
        Task<IReadOnlyList<Compra>> GetComprasForUserAsync(string clienteEmail);
        Task<Compra> GetCompraByIdAsync(int id, string clienteEmail);
        Task<IReadOnlyList<MetodoEnvio>> GetMetodosEnvioAsync();
    }
}