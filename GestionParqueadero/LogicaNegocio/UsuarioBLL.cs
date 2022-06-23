using AccesoDatos.Repositorio.Entidades;
using AutoMapper;
using LogicaNegocio.Modelos;

namespace LogicaNegocio
{
    public class UsuarioBLL
    {
        private AccesoDatos.UsuarioDAL _DAL;

        private Mapper _UsuarioMapper;

        public UsuarioBLL()
        {

            _DAL = new AccesoDatos.UsuarioDAL();
            var _configUsuario = new MapperConfiguration(cfg => cfg.CreateMap<Usuario, UsuarioModel>().ReverseMap());

            _UsuarioMapper = new Mapper(_configUsuario);
        }

        public List<UsuarioModel> GetAllUsuarios()
        {
            List<Usuario> usuariosFromDB = _DAL.GetAllUsuarios();
            List<UsuarioModel> usuariosModel = _UsuarioMapper.Map<List<Usuario>, List<UsuarioModel>>(usuariosFromDB);

            return usuariosModel;
        }

        public UsuarioModel GetUsuarioByNombre(string nombreUsuario)
        {
            var usuarioEntidad = _DAL.GetUsuarioByNombre(nombreUsuario);

            UsuarioModel userModel = _UsuarioMapper.Map<Usuario, UsuarioModel>(usuarioEntidad);

            return userModel;
        }


        public void postUsuario(UsuarioModel userModelo)
        {
            Usuario usuarioEntidad = _UsuarioMapper.Map<UsuarioModel, Usuario>(userModelo);
            _DAL.postUsuario(usuarioEntidad);
        }
    }
}
