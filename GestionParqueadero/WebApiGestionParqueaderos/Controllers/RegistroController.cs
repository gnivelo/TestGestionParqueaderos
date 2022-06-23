using AccesoDatos;
using AccesoDatos.Repositorio.Entidades;
using LogicaNegocio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiGestionParqueaderos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : Controller
    {
        private LogicaNegocio.RegistroBLL _BLL;
        public RegistroController()
        {
            _BLL = new LogicaNegocio.RegistroBLL();
        }


        [HttpGet]
        [Route("getRegistros")]


        public List<RegistroModel> GetAllRegistros()
        {
            return _BLL.GetAllRegistros();
        }



        [HttpGet]
        [Route("getRegistro")]
        public ActionResult<RegistroModel> GetRegistrosByPlaca(string id)
        {
            var registros = _BLL.GetRegistrosByPlaca(id);

            if (registros == null)
            {
                return NotFound("No se encuentran registros");
            }

            return Ok(registros);
        }




        [Route("postRegistro")]
        [HttpPost]
        public void postRegistro([FromBody] RegistroModel regModelo)
        {
            _BLL.postRegistro(regModelo);
        }

        [Route("deleteRegistro")]
        [HttpDelete]
        public void deleteRegistro([FromBody] RegistroModel regModelo)
        {
            _BLL.deleteRegistro(regModelo);
        }
    }
}
