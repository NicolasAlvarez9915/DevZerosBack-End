using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Interesado: Persona
    {
        [Column(TypeName = "Date")]
        public DateTime FechaRegistro { get; set; }
    }
}
