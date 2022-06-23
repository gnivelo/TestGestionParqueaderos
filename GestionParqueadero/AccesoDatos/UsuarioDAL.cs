using AccesoDatos.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UsuarioDAL
    {
        public List<Usuario> GetAllUsuarios()
        {
            var db = new GenericDbContext();
            return db.Usuario.ToList();
        }

        public Usuario GetUsuarioByNombre(string nombreUsuario)
        {
            var db = new GenericDbContext();
            Usuario p = new Usuario();

            p = db.Usuario.FirstOrDefault(x => x.NombreUsuario == nombreUsuario);

            return p;
        }


        public void postUsuario(Usuario usuario)
        {
            var db = new GenericDbContext();
            db.Add(usuario);
            db.SaveChanges();
        }

    }
}
