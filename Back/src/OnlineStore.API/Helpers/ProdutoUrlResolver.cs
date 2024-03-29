using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using OnlineStore.API.Dtos;

namespace OnlineStore.API.Helpers
{
    public class ProdutoUrlResolver : IValueResolver<Produto, ProdutoToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProdutoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Produto source, ProdutoToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.FotoUrl))
            {
                return _config["ApiUrl"] + source.FotoUrl;
            }

            return null;
        }
    }
}