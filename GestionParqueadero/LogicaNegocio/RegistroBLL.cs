using AutoMapper;
using AccesoDatos.Repositorio.Entidades;
using LogicaNegocio.Modelos;

namespace LogicaNegocio
{
    public class RegistroBLL
    {
        private AccesoDatos.RegistroDAL _DAL;

        private Mapper _RegistroMapper;

        public RegistroBLL()
        {
            _DAL = new AccesoDatos.RegistroDAL();
            var _configRegistro = new MapperConfiguration(cfg => cfg.CreateMap<Registro, RegistroModel>().ReverseMap());
            _RegistroMapper = new Mapper(_configRegistro);
        }

        public List<RegistroModel> GetAllRegistros()
        {
            List<Registro> registrosFromDB = _DAL.GetAllRegistro();
            List<RegistroModel> registrosModel = _RegistroMapper.Map<List<Registro>, List<RegistroModel>>(registrosFromDB);
            return registrosModel;
        }

        public RegistroModel GetRegistrosByPlaca(string placa)
        {
            var registroEntidad = _DAL.GetRegistroByPlaca(placa);
            RegistroModel registroModel = _RegistroMapper.Map<Registro, RegistroModel>(registroEntidad);
            return registroModel;
        }


        public void postRegistro(RegistroModel registroModelo)
        {
            Registro registroEntidad = _RegistroMapper.Map<RegistroModel, Registro>(registroModelo);
            _DAL.postRegistro(registroEntidad);
        }

        public void deleteRegistro(RegistroModel registroModelo)
        {
            Registro registroEntidad = _RegistroMapper.Map<RegistroModel, Registro>(registroModelo);
            _DAL.deleteRegistro(registroEntidad);
        }
    }
}
