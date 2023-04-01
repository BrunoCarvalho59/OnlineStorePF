using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Compras;

namespace Core.Specifications
{
    public class ComprasWithItemsAndCompraSpecification : BaseSpecification<Compra>
    {
        public ComprasWithItemsAndCompraSpecification(string email) : base(o => o.ClienteEmail == email)
        {
            AddInclude(o => o.CompraItems);
            AddInclude(o => o.MetodoEnvio);
            AddOrderByDescending(o => o.CompraData);
        }

        public ComprasWithItemsAndCompraSpecification(int id, string email) 
            : base(o => o.Id == id && o.ClienteEmail == email)
        {
            AddInclude(o => o.CompraItems);
            AddInclude(o => o.MetodoEnvio);
        }
    }
}