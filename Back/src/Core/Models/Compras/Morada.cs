using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.Compras
{
    public class Morada
    {
        public Morada()
        {
        }

        public Morada(string primeiroNome, string ultimoNome, string rua, string localidade, string country, string zip)
        {

            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
            Rua = rua;
            Localidade = localidade;
            Country = country;
            Zip = zip;
        }

        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Rua { get; set; }
        public string Localidade { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }
}