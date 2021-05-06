using System;
using System.Text.Json.Serialization;

namespace Api.Modelos
{
    public class SessionEntrada
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
    public class SessionVista
    {
        public string IdPersona { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        [JsonIgnore] 
        public string Password { get; set; }
         public string Token { get; set; }
    }
}
