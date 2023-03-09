using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Infrastructure.Data;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly StoreContext _context; //isto dá-nos acesso ao Dbcontext, injeção de dependencia
        public ProdutosController(StoreContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProducts()
        {
            var produtos = await _context.Produtos.ToListAsync();

            return produtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduct(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }
    }
}