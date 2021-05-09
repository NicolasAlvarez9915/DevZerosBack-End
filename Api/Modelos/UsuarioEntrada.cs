using System;
using Entidad;

namespace Api.Modelos
{
    public class UsuarioEntrada
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public string IdPersona { get; set; }
        public string Estado { get; set; }
    }

    public class UsuarioVista: UsuarioEntrada
    {
        public UsuarioVista()
        {

        }
        public UsuarioVista(Usuario usuario)
        {
            Correo = usuario.Correo;
            Contrasena = usuario.Contraseña;
            Rol = usuario.Rol;
            IdPersona = usuario.Identificacion;
            Estado = usuario.Estado;
        }
    }
}
