using AccesoDatos.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CajaDAL
    {
        public List<Caja> GetAllCaja()
        {
            var db = new GenericDbContext();
            return db.Caja.ToList();
        }

        public Caja GetCajaById(long id)
        {
            var db = new GenericDbContext();
            Caja p = new Caja();

            p = db.Caja.FirstOrDefault(x => x.Id == id);

            return p;
        }

        public void postCaja(Caja pago)
        {
            var db = new GenericDbContext();
            db.Add(pago);
            db.SaveChanges();
        }

        public void deleteCaja(Caja pago)
        {
            var db = new GenericDbContext();
            db.Remove(pago);
            db.SaveChanges();
        }
    }
}
