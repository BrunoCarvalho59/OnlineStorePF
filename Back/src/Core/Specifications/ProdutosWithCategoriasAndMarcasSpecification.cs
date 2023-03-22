using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Specifications
{
    public class ProdutosWithCategoriasAndMarcasSpecification : BaseSpecification<Produto>
    {
        public ProdutosWithCategoriasAndMarcasSpecification(ProductSpecParams productParams) 
            : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Nome.ToLower().Contains
                (productParams.Search)) && 
                (!productParams.MarcaId.HasValue || x.ProdutoMarcaId == productParams.MarcaId) && 
                (!productParams.CategoriaId.HasValue || x.ProdutoCategoriaId == productParams.CategoriaId)
            )
        {
            AddInclude(x => x.ProdutoCategoria);
            AddInclude(x => x.ProdutoMarca);
            AddOrderBy(x => x.Nome);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Preco);
                        break;
                    case "priceDes":
                        AddOrderByDescending(p => p.Preco);
                        break;
                    default:
                        AddOrderBy(n => n.Nome);
                        break;
                }

            }
        }

        public ProdutosWithCategoriasAndMarcasSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProdutoCategoria);
            AddInclude(x => x.ProdutoMarca);
        }
    }
}