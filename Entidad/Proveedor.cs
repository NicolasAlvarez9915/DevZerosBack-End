using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string Nit { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }
    }
}
