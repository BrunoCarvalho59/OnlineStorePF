using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Basket
{
    public class BasketCliente
    {
        public BasketCliente() //Esse construtor é usado pelo Entity Framework para criar instâncias do objeto a partir do banco de dados.
        {
        }

        public BasketCliente(string id) //Este construtor é útil para criar novos objetos BasketCliente na aplicação antes de adicioná-los ao banco de dados.
        {
            Id = id;
        }

        public string Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public DateTime lastUpdated { get; set; }
    }
}