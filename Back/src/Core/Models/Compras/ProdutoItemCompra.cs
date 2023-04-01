using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Compras
{
    public class ProdutoItemCompra
    {
        public ProdutoItemCompra()
        {
        }

        public ProdutoItemCompra(int produtoItemId, string produtoNome, string fotoUrl)
        {
            ProdutoItemId = produtoItemId;
            ProdutoNome = produtoNome;
            FotoUrl = fotoUrl;
        }

        public int ProdutoItemId { get; set; }
        public string ProdutoNome { get; set; }
        public string FotoUrl { get; set; }
    }
}