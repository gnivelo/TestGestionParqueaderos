using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicaNegocio.Modelos
{
    public class UsuarioModel
    {

        public Decimal Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "La contrasenia es obligatoria")]
        public string Clave { get; set; }



    }
}
