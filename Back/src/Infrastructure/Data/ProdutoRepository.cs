using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly StoreContext _context; //isto dá-nos acesso ao Dbcontext, injeção de dependencia

        public ProdutoRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _context.Produtos
                .Include(p => p.ProdutoCategoria)
                .Include(P => P.ProdutoMarca)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            return await _context.Produtos
                .Include(p => p.ProdutoCategoria)
                .Include(P => P.ProdutoMarca)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProdutoCategoria>> GetCategoriasAsync()
        {
            return await _context.Categorias.ToListAsync();

        }

        public async Task<IReadOnlyList<ProdutoMarca>> GetMarcasAsync()
        {
            return await _context.Marcas.ToListAsync();
        }

    }
}