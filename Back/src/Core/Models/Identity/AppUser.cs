using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Core.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayNome { get; set; }
        public Morada Morada { get; set; }
    }
}