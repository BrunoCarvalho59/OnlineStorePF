using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Dtos
{
    public class MoradaDto
    {
        [Required]
        public string PrimeiroNome { get; set; }
        [Required]
        public string UltimoNome { get; set; }
        [Required]
        public string Rua { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Zip { get; set; }
    }
}