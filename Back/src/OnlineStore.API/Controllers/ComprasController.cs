using AutoMapper;
using Core.Interfaces;
using Core.Models.Compras;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Dtos;
using OnlineStore.API.Erros;
using OnlineStore.API.Extensions;

namespace OnlineStore.API.Controllers
{
    [Authorize]
    public class ComprasController : BaseApiController
    {
        private readonly IComprasService _comprasService;
        private readonly IMapper _mapper;
        public ComprasController(IComprasService comprasService, IMapper mapper)
        {
            _mapper = mapper;
            _comprasService = comprasService;
        }

        [HttpPost]
        public async Task<ActionResult<Compra>> CreateCompra(CompraDto compraDto)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var morada = _mapper.Map<MoradaDto, Morada>(compraDto.MoradaEnvio);

            var compra = await _comprasService.CreateCompraAsync(email, compraDto.MetodoEnvioId, compraDto.basketId, morada);

            if (compra == null) return BadRequest(new ApiResponse(400, "Problema ao efetuar a compra"));

            return Ok(compra);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompraDto>>> GetOrdersForUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var compras = await _comprasService.GetComprasForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<Compra>, IReadOnlyList<CompraToReturnDto>>(compras));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompraToReturnDto>> GetCompraByIdForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();

            var compra = await _comprasService.GetCompraByIdAsync(id, email);

            if (compra == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Compra, CompraToReturnDto>(compra);
        }

        [HttpGet("metodosEnvio")]
        public async Task<ActionResult<IReadOnlyList<MetodoEnvio>>> GetMetodosEnvio()
        {
            return Ok(await _comprasService.GetMetodosEnvioAsync());
        }
    }

    
}