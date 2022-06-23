using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos.Repositorio.Entidades
{
    public partial class Usuario
    {
        [Key]
        [Column("id")]
        public Decimal Id { get; set; }

        [Column("usuario")]
        [StringLength(30)]
        public string NombreUsuario { get; set; }

        [Column("clave")]
        [StringLength(50)]
        public string Clave { get; set; }


        


    }
}
