using AccesoDatos.Repositorio.Entidades;
using AutoMapper;
using LogicaNegocio.Modelos;

namespace LogicaNegocio
{
    public class VehiculoBLL
    {
        private AccesoDatos.VehiculoDAL _DAL;

        private Mapper _VehiculoMapper;

        public VehiculoBLL()
        {
            _DAL = new AccesoDatos.VehiculoDAL();
            var _configVehiculo = new MapperConfiguration(cfg => cfg.CreateMap<Vehiculo, VehiculoModel>().ReverseMap());
            _VehiculoMapper = new Mapper(_configVehiculo);
        }

        public List<VehiculoModel> GetAllVehiculos()
        {
            List<Vehiculo> vehiculosFromDB = _DAL.GetAllVehiculos();
            List<VehiculoModel> vehiculosModel = _VehiculoMapper.Map<List<Vehiculo>, List<VehiculoModel>>(vehiculosFromDB);
            return vehiculosModel;
        }

        public VehiculoModel GetVehiculoByPlaca(string placa)
        {
            var vehiculoEntidad = _DAL.GetVehiculoByPlaca(placa);
            VehiculoModel vehiculoModel = _VehiculoMapper.Map<Vehiculo, VehiculoModel>(vehiculoEntidad);
            return vehiculoModel;
        }


        public void postVehiculo(VehiculoModel vehiculoModelo)
        {
            Vehiculo vehiculoEntidad = _VehiculoMapper.Map<VehiculoModel, Vehiculo>(vehiculoModelo);
            _DAL.postVehiculo(vehiculoEntidad);
        }

        public void deleteVehiculo(VehiculoModel vehiculoModelo)
        {
            Vehiculo vehiculoEntidad = _VehiculoMapper.Map<VehiculoModel, Vehiculo>(vehiculoModelo);
            _DAL.deleteVehiculo(vehiculoEntidad);
        }
    }
}
