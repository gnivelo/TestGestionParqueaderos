using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos.Repositorio.Entidades
{
    //internal class Cliente
    //{
    //}
    public partial class Cliente
    {
        [Key]
        [Column("id")]
        public string NumeroDocumento { get; set; }

        [Column("nombres")]
        [StringLength(50)]

        //[RegularExpression(@"\A[^\d_]+\z", ErrorMessage = "Tipo de datos invalido")]
        public string Nombres { get; set; }

        [Column("apellidos")]
        [StringLength(50)]
        public string Apellidos { get; set; }


        [Column("direccion")]
        [StringLength(250)]
        public string Direccion { get; set; }

        [Column("telefono")]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Column("email")]
        [StringLength(50)]
        public string? Email { get; set; }


    }
}
