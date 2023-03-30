using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Core.Models.Basket;
using Core.Models.Utilizador;
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
            CreateMap<MoradaDto, Morada>().ReverseMap();
            CreateMap<BasketClienteDto, BasketCliente>();
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}