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
    public class VehiculoController : Controller
    {
        private LogicaNegocio.VehiculoBLL _BLL;
        public VehiculoController()
        {
            _BLL = new LogicaNegocio.VehiculoBLL();
        }


        [HttpGet]
        [Route("getVehiculos")]
        public List<VehiculoModel> GetAllVehiculos()
        {
            return _BLL.GetAllVehiculos();
        }



        [HttpGet]
        [Route("getVehiculo")]
        public ActionResult<VehiculoModel> GetVehiculosByPlaca(string id)
        {
            var vehiculos = _BLL.GetVehiculoByPlaca(id);

            if (vehiculos == null)
            {
                return NotFound("No se encuentran vehiculos");
            }

            return Ok(vehiculos);
        }




        [Route("postVehiculos")]
        [HttpPost]
        public void postVehiculo([FromBody] VehiculoModel vehiculoModelo)
        {
            _BLL.postVehiculo(vehiculoModelo);
        }

        [Route("deleteVehiculo")]
        [HttpDelete]
        public void deleteVehiculo([FromBody] VehiculoModel vehiculoModelo)
        {
            _BLL.deleteVehiculo(vehiculoModelo);
        }
    }
}
