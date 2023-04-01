using System.ComponentModel.DataAnnotations;

namespace Core.Models.Identity
{
    public class Morada
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Rua { get; set; }
        public string Localidade { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}