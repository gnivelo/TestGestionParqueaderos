using AccesoDatos;
using AccesoDatos.Repositorio.Entidades;
using LogicaNegocio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApiGestionParqueaderos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private LogicaNegocio.ClienteBLL _BLL;
        public ClienteController()
        {
            _BLL = new LogicaNegocio.ClienteBLL();
        }

        //
        /// <summary>
        /// Consulta todos los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getClientes")]


        public List<ClienteModel> GetAllClientes()
        {
            return _BLL.GetAllClientes();
        }


        /// <summary>
        /// Consulta por un cliente en funcion de su numero de identificacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCliente")]
        public ActionResult<ClienteModel> GetPersonById(string id)
        {
            var cliente = _BLL.GetClienteById(id);

            if (cliente == null)
            {
                return NotFound("Numero de documento invalido");
            }

            return Ok(cliente);
        }



        /// <summary>
        /// Metodo para agregar clientes
        /// </summary>
        /// <param name="clienteModelo"></param>
        [Route("postCliente")]
        [HttpPost]
        public void postCliente([FromBody] ClienteModel clienteModelo)
        {
            _BLL.postCliente(clienteModelo);
        }

        /// <summary>
        /// Metodo para eliminar clientes
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        [Route("deleteCliente")]
        [HttpDelete]
        public void deleteCliente(string id)
        {
            var db = new GenericDbContext();
            Cliente p = new Cliente();
            p = db.Cliente.FirstOrDefault(x => x.NumeroDocumento == id);

            if (p == null)
                throw new Exception("Codigo de cliente no encontrado");

            db.Cliente.Remove(p);
            db.SaveChanges();
        }
    }
}
