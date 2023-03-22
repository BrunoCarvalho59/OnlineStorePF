using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models.Utilizador;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.GivenName, user.DisplayNome ?? string.Empty),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
    /*Este código define um serviço de token chamado "TokenService" que implementa a interface "ITokenService" e 
    gera tokens JWT com base nas informações do usuário fornecidas. O token gerado pode ser usado para autenticação 
    e autorização em um sistema ou aplicativo. O JWT é um padrão amplamente utilizado para transmitir informações de 
    forma segura entre partes, como um cliente e um servidor. Neste caso, o token gerado pode ser usado para autenticar 
    um usuário e garantir que ele tenha acesso apenas aos recursos autorizados dentro do aplicativo.

    Ao usar esse serviço, você pode criar um token para um usuário após um processo de login bem-sucedido. O token é então 
    enviado para o cliente e armazenado localmente (por exemplo, em um cookie ou no armazenamento local do navegador). Em 
    solicitações subsequentes, o cliente inclui o token no cabeçalho de autorização, permitindo que o servidor valide o token 
    e verifique se o usuário tem permissão para acessar os recursos solicitados. */
}