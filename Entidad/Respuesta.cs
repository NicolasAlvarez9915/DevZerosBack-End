using System;

namespace Entidad
{
    public class Respuesta<T>
    {
        public T Objecto { get; set; }
        public bool Error { get; set; } 
        public String Mensaje { get; set; }

        public Respuesta(T Objecto)
        {
            Error = false;
            this.Objecto = Objecto;
        }
        public Respuesta(string mensaje)
        {
            Error = true;
            this.Mensaje = mensaje;
        }
    }
}
