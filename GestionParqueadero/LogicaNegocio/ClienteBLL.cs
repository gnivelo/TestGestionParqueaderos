

using AccesoDatos.Repositorio.Entidades;
using AutoMapper;
using LogicaNegocio.Modelos;

namespace LogicaNegocio
{
    public class ClienteBLL
    {
        private AccesoDatos.ClienteDAL _DAL;

        private Mapper _ClienteMapper;

        public ClienteBLL()
        {

            _DAL = new AccesoDatos.ClienteDAL();
            var _configCliente = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteModel>().ReverseMap());

            _ClienteMapper = new Mapper(_configCliente);
        }

        public List<ClienteModel> GetAllClientes()
        {
            List<Cliente> clientesFromDB = _DAL.GetAllClientes();
            List<ClienteModel> clientesModel = _ClienteMapper.Map<List<Cliente>, List<ClienteModel>>(clientesFromDB);

            return clientesModel;
        }

        public ClienteModel GetClienteById(string id)
        {
            var clienteEntidad = _DAL.GetClienteById(id);

            ClienteModel clienteModel = _ClienteMapper.Map<Cliente, ClienteModel>(clienteEntidad);

            return clienteModel;
        }


        public void postCliente(ClienteModel clienteModelo)
        {
            Cliente clienteEntidad = _ClienteMapper.Map<ClienteModel, Cliente>(clienteModelo);
            _DAL.postCliente(clienteEntidad);
        }


    }
}