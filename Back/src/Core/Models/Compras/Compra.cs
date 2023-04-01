using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Compras
{
    public class Compra : BaseEntity
    {
        public Compra()
        {
        }

        public Compra(IReadOnlyList<CompraItem> compraItems, int? id, string clienteEmail, Morada moradaEnvio, 
        MetodoEnvio metodoEnvio, decimal subTotal)
        {
            Id = id;
            ClienteEmail = clienteEmail;
            MoradaEnvio = moradaEnvio;
            MetodoEnvio = metodoEnvio;
            CompraItems = compraItems;
            SubTotal = subTotal;
        }

        public int? Id { get; set; }
        public string ClienteEmail { get; set; }
        public DateTime CompraData { get; set; } = DateTime.UtcNow;
        public Morada MoradaEnvio { get; set; }
        public MetodoEnvio MetodoEnvio { get; set; }
        public IReadOnlyList<CompraItem> CompraItems { get; set; }
        public decimal SubTotal { get; set; }
        public CompraStatus Status { get; set; } = CompraStatus.Pendente;

        public decimal GetTotal() //Importante o Get para que o mapper para uma propriedade chamada Total
        {
            return SubTotal + MetodoEnvio.Preco;
        }
    }
}