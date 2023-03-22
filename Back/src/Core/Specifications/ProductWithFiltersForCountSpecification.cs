using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Produto>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)             
            : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Nome.ToLower().Contains
                (productParams.Search)) && 
                (!productParams.MarcaId.HasValue || x.ProdutoMarcaId == productParams.MarcaId) && 
                (!productParams.CategoriaId.HasValue || x.ProdutoCategoriaId == productParams.CategoriaId)
            )
        {
        }
    }
}