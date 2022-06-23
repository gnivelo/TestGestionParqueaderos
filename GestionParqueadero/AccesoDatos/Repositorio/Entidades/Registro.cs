using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos.Repositorio.Entidades
{
    public partial class Registro
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("fecha_entrada")]
        public DateTime FechaIngreso { get; set; }

        [Column("fecha_salida")]
        public DateTime FechaSalida { get; set; }

        [Column("placa")]
        [StringLength(20)]
        public string PlacaVehiculo { get; set; }
    }
}
