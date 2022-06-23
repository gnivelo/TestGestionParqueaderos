using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AccesoDatos.Repositorio.Entidades;
using LogicaNegocio.Modelos;

namespace WebApiGestionParqueaderos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class LoginController : ControllerBase
    {
        private readonly JwtAuthenticationManager ctx;
        private LogicaNegocio.UsuarioBLL _userBLL;
        public LoginController(JwtAuthenticationManager _ctx)
        {
            this.ctx = _ctx;
            this._userBLL = new LogicaNegocio.UsuarioBLL();
        }


        
        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUSer([FromBody] UsuarioModel usuario)
        {
            UsuarioModel user = _userBLL.GetUsuarioByNombre(usuario.NombreUsuario);

            if (user == null)
            {
                return NotFound("Nombre de usuario no ecnontrado");
            }

            var token = ctx.Authenticate(usuario.NombreUsuario, usuario.Clave, user);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();
            return Ok(token);
        }

        [HttpGet]
        public IActionResult TestRoute()
        {
            return Ok("Authorizado");
        }
    }
}
