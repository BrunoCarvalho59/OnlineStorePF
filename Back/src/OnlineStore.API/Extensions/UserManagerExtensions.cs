using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Models.Utilizador;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipleWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

            return await userManager.Users.Include(x => x.Morada)
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            return await userManager.Users
                .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
        }
    }
}