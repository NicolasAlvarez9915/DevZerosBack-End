using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Factura
    {
        [Key]
        public int Codigo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaFactura { get; set; }
    }
}
