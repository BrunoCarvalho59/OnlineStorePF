using System.ComponentModel.DataAnnotations;

namespace Core.Models.Utilizador
{
    public class Morada
    {
        public int Id { get; set; }
        public string primeiroNome { get; set; }
        public string ultimoNome { get; set; }
        public string rua { get; set; }
        public string localidade { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        
        [Required]
        public string appUserId { get; set; }
        public AppUser appUser { get; set; }

    }
}