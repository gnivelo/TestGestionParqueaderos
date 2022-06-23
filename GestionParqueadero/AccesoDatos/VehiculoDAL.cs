using AccesoDatos.Repositorio.Entidades;

namespace AccesoDatos
{
    public class VehiculoDAL
    {

        public List<Vehiculo> GetAllVehiculos()
        {
            var db = new GenericDbContext();
            return db.Vehiculo.ToList();
        }

        public Vehiculo GetVehiculoByPlaca(string placa)
        {
            var db = new GenericDbContext();
            Vehiculo p = new Vehiculo();

            p = db.Vehiculo.FirstOrDefault(x => x.PlacaVehiculo == placa);

            return p;
        }


        public void postVehiculo(Vehiculo auto)
        {
            var db = new GenericDbContext();
            db.Add(auto);
            db.SaveChanges();
        }

        public void deleteVehiculo(Vehiculo auto)
        {
            var db = new GenericDbContext();
            db.Remove(auto);
            db.SaveChanges();
        }
    }
}
