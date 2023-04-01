using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Core.Models.Compras;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class CompraService : IComprasService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitofWork;

        public CompraService(IBasketRepository basketRepo, IUnitOfWork unitofWork)
        {
            _basketRepo = basketRepo;
            _unitofWork = unitofWork;
        }

        public async Task<Compra> CreateCompraAsync(string clienteEmail, int metodoEnvioId, string basketId, Morada moradaEnvio)
        {
            //Get basket do repo
            var basket = await _basketRepo.GetBasketAsync(basketId);
            
            //Get items do produto repo
            var items = new List<CompraItem>();
            foreach (var item in basket.Items)
            {
                var produtoItem = await _unitofWork.Repository<Produto>().GetByIdAsync(item.Id);
                var itemPedido = new ProdutoItemCompra(produtoItem.Id, produtoItem.Nome, produtoItem.FotoUrl);
                var compraItem = new CompraItem(null , itemPedido, produtoItem.Preco, item.Quantidade);
                items.Add(compraItem);
                
            }
            
            //Get metodo do repo
            var metodoEnvio = await _unitofWork.Repository<MetodoEnvio>().GetByIdAsync(metodoEnvioId);
            
            //calcular subtotal
            var subtotal = items.Sum(item => item.Preco * item.Quantidade);
            
            //criar compra
            var compra = new Compra(items, null, clienteEmail, moradaEnvio, metodoEnvio, subtotal);
            _unitofWork.Repository<Compra>().Add(compra);
            
            //salvar na db
            var result = await _unitofWork.Complete();

            if (result <= 0) return null;

            //delete basket
            await _basketRepo.DeleteBasketAsync(basketId);
            
            //Return compra
            return compra;
        }

        public async Task<Compra> GetCompraByIdAsync(int id, string clienteEmail)
        {
            var spec = new ComprasWithItemsAndCompraSpecification(id, clienteEmail);

            return await _unitofWork.Repository<Compra>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Compra>> GetComprasForUserAsync(string clienteEmail)
        {
            var spec = new ComprasWithItemsAndCompraSpecification(clienteEmail);

            return await _unitofWork.Repository<Compra>().ListAsync(spec);
        }

        public async Task<IReadOnlyList<MetodoEnvio>> GetMetodosEnvioAsync()
        {
            return await _unitofWork.Repository<MetodoEnvio>().ListAllAsync();
        }
    }
}