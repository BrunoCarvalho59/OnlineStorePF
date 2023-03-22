using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.Interfaces;
using Core.Specifications;
using OnlineStore.API.Dtos;
using AutoMapper;
using OnlineStore.API.Helpers;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IGenericRepository<Produto> _produtosRepo;
        private readonly IGenericRepository<ProdutoMarca> _produtosMarcaRepo;
        private readonly IGenericRepository<ProdutoCategoria> _produtosCategoriaRepo;
        private readonly IMapper _mapper;

        public ProdutosController(IGenericRepository<Produto>produtosRepo, IGenericRepository<ProdutoMarca> produtosMarcaRepo, IGenericRepository<ProdutoCategoria> produtosCategoriaRepo, IMapper mapper)
        {
            _produtosCategoriaRepo = produtosCategoriaRepo;
            _mapper = mapper;
            _produtosRepo = produtosRepo;
            _produtosMarcaRepo = produtosMarcaRepo;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ProdutoToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProdutosWithCategoriasAndMarcasSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _produtosRepo.CountAsync(countSpec);
            
            var produtos = await _produtosRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Produto>, IReadOnlyList<ProdutoToReturnDto>>(produtos);

            return Ok(new Pagination<ProdutoToReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoToReturnDto>> GetProduct(int id)
        {
            var spec = new ProdutosWithCategoriasAndMarcasSpecification(id);

            var produto = await _produtosRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Produto, ProdutoToReturnDto>(produto);
        }


        [HttpGet("categorias")]
        public async Task<ActionResult<IReadOnlyList<ProdutoCategoria>>> GetCategorias()
        {
            var categorias = await _produtosCategoriaRepo.ListAllAsync();

            return Ok(categorias);
        }

        [HttpGet("marcas")]
        public async Task<ActionResult<IReadOnlyList<ProdutoMarca>>> GetMarcas()
        {
            var marcas = await _produtosMarcaRepo.ListAllAsync();

            return Ok(marcas);
        }

        //[Authorize(Roles = "Admin, GestorLoja")] //Exemplo de gestão de produtos
        //[HttpPost]
        
    

        private async Task<ActionResult<Produto>> GetProductid(int id)
        {
            return await _produtosRepo.GetByIdAsync(id);
        }
    }
}