using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using AccesoDatos.Repositorio.Entidades;
using LogicaNegocio.Modelos;

namespace WebApiGestionParqueaderos
{
    public class JwtAuthenticationManager
    {
        private readonly string key;

        public IConfiguration Configuration { get; }
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string? Authenticate(string username, string password, UsuarioModel users)
        {
            
            //consultar usuarios

            if (!(users.NombreUsuario == username && users.Clave == password))
            {
                return null;
            }
            var secretKey = key; 
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                // Duracion del token
                Expires = DateTime.UtcNow.AddHours(2),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature) 
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
