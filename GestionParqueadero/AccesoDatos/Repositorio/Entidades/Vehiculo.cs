using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccesoDatos.Repositorio.Entidades
{
    public partial class Vehiculo
    {
        [Key]
        [Column("placa")]
        [StringLength(15)]
        public string PlacaVehiculo { get; set; }

        [Column("marca")]
        [StringLength(50)]
        public string? MarcaVehiculo { get; set; }

        [Column("modelo")]
        [StringLength(50)]
        public string? ModeloVehiculo { get; set; }

        [Column("color")]
        [StringLength(50)]
        public string? ColorVehiculo { get; set; }


        [Column("tipo")]
        [StringLength(50)]
        public string? TipoVehiculo { get; set; }

    }
}
