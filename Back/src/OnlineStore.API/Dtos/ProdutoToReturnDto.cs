using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Dtos
{
    public class ProdutoToReturnDto
    {
         public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string FotoUrl { get; set; }
        public string ProdutoCategoria { get; set; }
        public string ProdutoMarca { get; set; }
    }
}