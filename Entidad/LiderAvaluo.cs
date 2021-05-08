using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class LiderAvaluo:Persona
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Puesto { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaContratacion { get; set; }
    }
}
