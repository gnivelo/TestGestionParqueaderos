using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class RegistroModel
    {
        public string Id { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaSalida { get; set; }

        public string PlacaVehiculo { get; set; }
    }
}
