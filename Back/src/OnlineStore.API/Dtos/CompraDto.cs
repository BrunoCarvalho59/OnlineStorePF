using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Dtos
{
    public class CompraDto
    {
        public string basketId { get; set; }
        public int MetodoEnvioId { get; set; }
        public MoradaDto MoradaEnvio { get; set; }
    }
}