using AccesoDatos.Repositorio.Entidades;
using AutoMapper;
using LogicaNegocio.Modelos;

namespace LogicaNegocio
{
    public class CajaBLL
    {
        private AccesoDatos.CajaDAL _DAL;

        private Mapper _CajaMapper;

        public CajaBLL()
        {

            _DAL = new AccesoDatos.CajaDAL();
            var _configCaja = new MapperConfiguration(cfg => cfg.CreateMap<Caja, CajaModel>().ReverseMap());

            _CajaMapper = new Mapper(_configCaja);
        }

        public List<CajaModel> GetAllCajas()
        {
            List<Caja> cajasFromDB = _DAL.GetAllCaja();
            List<CajaModel> cajasModel = _CajaMapper.Map<List<Caja>, List<CajaModel>>(cajasFromDB);

            return cajasModel;
        }

        public CajaModel GetCajaById(long id)
        {
            var cajaEntidad = _DAL.GetCajaById(id);

            CajaModel cajaModel = _CajaMapper.Map<Caja, CajaModel>(cajaEntidad);

            return cajaModel;
        }


        public void postCaja(CajaModel cajaModelo)
        {
            Caja cajaEntidad = _CajaMapper.Map<CajaModel, Caja>(cajaModelo);
            _DAL.postCaja(cajaEntidad);
        }
    }
}
