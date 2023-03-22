using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Dtos
{
    public class RegistoDto
    {
        [Required]
        public string DisplayNome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Password tem que ter 1 letra maiúscula, 1 letra minúscula, 1 algarismo, 1 não alfanumérico e pelo menos 6 caracteres.")]
        public string Password { get; set; }
    }
}