using AccesoDatos.Repositorio.Entidades;

namespace AccesoDatos
{
    public class ClienteDAL
    {
        public List<Cliente> GetAllClientes()
        {
            var db = new GenericDbContext();
            return db.Cliente.ToList();
        }

        public Cliente GetClienteById(string id)
        {
            var db = new GenericDbContext();
            Cliente p = new Cliente();

            p = db.Cliente.FirstOrDefault(x => x.NumeroDocumento == id);

            return p;
        }


        public void postCliente(Cliente cliente)
        {
            var db = new GenericDbContext();
            db.Add(cliente);
            db.SaveChanges();
        }

    }
}