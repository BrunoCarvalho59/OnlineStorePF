using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models.Compras;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Helpers
{
    public class CompraItemUrlResolver : IValueResolver<CompraItem, CompraItemDto, string>
    {
        private readonly IConfiguration _config;
        public CompraItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(CompraItem source, CompraItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemPedido.FotoUrl))
            {
                return _config["ApiUrl"] + source.ItemPedido.FotoUrl;
            }

            return null;
        }
    }
}