using AutoMapper;
using Core.Models;
using Core.Models.Basket;
using Core.Models.Compras;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Produto, ProdutoToReturnDto>()
                .ForMember(d => d.ProdutoMarca, o => o.MapFrom(s => s.ProdutoMarca.Nome))
                .ForMember(d => d.ProdutoCategoria, o => o.MapFrom(s => s.ProdutoCategoria.Nome))
                .ForMember(d => d.FotoUrl, o => o.MapFrom<ProdutoUrlResolver>());
            CreateMap<Core.Models.Identity.Morada, MoradaDto>().ReverseMap();
            CreateMap<BasketClienteDto, BasketCliente>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<MoradaDto, Core.Models.Compras.Morada>();
            CreateMap<Compra, CompraToReturnDto>()
                .ForMember(d => d.MetodoEnvio, o => o.MapFrom(s => s.MetodoEnvio.Nome))
                .ForMember(d => d.PrecoEnvio, o => o.MapFrom(s => s.MetodoEnvio.Preco));
            CreateMap<CompraItem, CompraItemDto>()
                .ForMember(d => d.ProdutoId, o => o.MapFrom(s =>  s.ItemPedido.ProdutoItemId))
                .ForMember(d => d.ProdutoNome, o => o.MapFrom(s =>  s.ItemPedido.ProdutoNome))
                .ForMember(d => d.FotoUrl, o => o.MapFrom(s =>  s.ItemPedido.FotoUrl))
                .ForMember(d => d.FotoUrl, o => o.MapFrom<CompraItemUrlResolver>()); 
        }
    }
}