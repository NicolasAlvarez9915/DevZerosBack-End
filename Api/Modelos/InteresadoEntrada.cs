using System;
using Entidad;

namespace Api.Modelos
{
    public class InteresadoEntrada
    {
        public string identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

    public class InteresadoVista: InteresadoEntrada
    {
        public InteresadoVista()
        {

        }
        public InteresadoVista(Interesado interesado)
        {
            identificacion = interesado.identificacion;
            Nombres = interesado.Nombres;
            Apellidos = interesado.Apellidos;
            Telefono = interesado.Telefono;
            FechaRegistro = interesado.FechaRegistro;
        }
    }
}
