using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Usuario
    {
        [Key]
        [Column(TypeName = "nvarchar(50)")]
        public string Correo { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string IdPersona { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Contraseña { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Rol { get; set; }
        [Column(TypeName = "nvarchar(4)")]
        public string Estado { get; set; }
    }
}
