using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos.Repositorio.Entidades
{
    public partial class Caja
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("id_registro")]
        public long IdRegistro { get; set; }

        [Column( "fecha")]
        public DateTime? Fecha { get; set; }

        [Column("valor")]
        public float Valor { get; set; }

        [Column("id_cliente")]
        public string IdCliente { get; set; }

        
    }
}
