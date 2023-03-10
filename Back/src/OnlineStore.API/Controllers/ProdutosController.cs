using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.Interfaces;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repo;

        public ProdutosController(IProdutoRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> GetProducts()
        {
            var produtos = await _repo.GetProdutosAsync();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduct(int id)
        {
            return await _repo.GetProdutoByIdAsync(id);
        }

        [HttpGet("marcas")]
        public async Task<ActionResult<List<ProdutoCategoria>>> GetCategorias()
        {
            var categorias = await _repo.GetCategoriasAsync();

            return Ok(categorias);
        }

        [HttpGet("categorias")]
        public async Task<ActionResult<List<ProdutoMarca>>> GetMarcas()
        {
            var marcas = await _repo.GetMarcasAsync();

            return Ok(marcas);
        }
    }
}