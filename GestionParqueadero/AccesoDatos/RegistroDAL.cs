using AccesoDatos.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class RegistroDAL
    {
        public List<Registro> GetAllRegistro()
        {
            var db = new GenericDbContext();
            return db.Registro.ToList();
        }

        public Registro GetRegistroByPlaca(string placa)
        {
            var db = new GenericDbContext();
            Registro p = new Registro();

            p = db.Registro.FirstOrDefault(x => x.PlacaVehiculo == placa);

            return p;
        }

        public void postRegistro(Registro regVehiculo)
        {
            var db = new GenericDbContext();
            db.Add(regVehiculo);
            db.SaveChanges();
        }

        public void deleteRegistro(Registro regVehiculo)
        {
            var db = new GenericDbContext();
            db.Remove(regVehiculo);
            db.SaveChanges();


            //var db = new GenericDbContext();
            //Registro p = new Registro();
            //p = db.Registro.FirstOrDefault(x => x.Id == id);

            //if (p == null)
            //    throw new Exception("Codigo de cliente no encontrado");

            //db.Registro.Remove(p);
            //db.SaveChanges();



        }

    }
}
