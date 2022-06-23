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
    public class CajaController : ControllerBase
    {
        private LogicaNegocio.CajaBLL _BLL;
        public CajaController()
        {
            _BLL = new LogicaNegocio.CajaBLL();
        }


        [HttpGet]
        [Route("getCajas")]
        public List<CajaModel> GetAllCajas()
        {
            return _BLL.GetAllCajas();
        }



        [HttpGet]
        [Route("getCaja")]
        public ActionResult<CajaModel> GetCajaById(long id)
        {
            var caja = _BLL.GetCajaById(id);

            if (caja == null)
            {
                return NotFound("Numero de documento invalido");
            }

            return Ok(caja);
        }




        [Route("postCaja")]
        [HttpPost]
        public void postCaja([FromBody] CajaModel cajaModelo)
        {
            _BLL.postCaja(cajaModelo);
        }

        [Route("deleteCaja")]
        [HttpDelete]
        public void deleteCaja(long id)
        {
            var db = new GenericDbContext();
            Caja p = new Caja();
            p = db.Caja.FirstOrDefault(x => x.Id == id);

            if (p == null)
                throw new Exception("Codigo de cliente no encontrado");

            db.Caja.Remove(p);
            db.SaveChanges();
        }
    }
}
