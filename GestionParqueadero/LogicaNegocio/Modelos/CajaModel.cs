using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class CajaModel
    {
        
        public long Id { get; set; }

        public long IdRegistro { get; set; }

        public DateTime? Fecha { get; set; }
        
        public float Valor { get; set; }
        
        public string IdCliente { get; set; }
    }
}
