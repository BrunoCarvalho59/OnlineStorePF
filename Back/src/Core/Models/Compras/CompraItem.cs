using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Compras
{
    public class CompraItem
    {
        public CompraItem()
        {
        }

        public CompraItem(int? id, ProdutoItemCompra itemPedido, decimal preco, decimal quantidade)
        {
            Id = id;
            ItemPedido = itemPedido;
            Preco = preco;
            Quantidade = quantidade;
        }

        public int? Id { get; set; }
        public ProdutoItemCompra ItemPedido { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}