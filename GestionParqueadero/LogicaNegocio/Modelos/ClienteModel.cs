using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Modelos
{
    public class ClienteModel
    {

        public string NumeroDocumento { get; set; }

        [RegularExpression(@"\A[^\d_]+\z", ErrorMessage = "Tipo de datos invalido")]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string? Email { get; set; }
    }
}
