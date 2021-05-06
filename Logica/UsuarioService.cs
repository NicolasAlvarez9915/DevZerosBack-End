using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class UsuarioService
    {
        private readonly NaacCelularesContext Context;
        public UsuarioService(NaacCelularesContext Context)
        {
            this.Context = Context;
        }

        public Usuario ValidarSession(Usuario usuario) 
        {
            return Context.Usuarios.FirstOrDefault(t => t.Correo == usuario.Correo && t.Contraseña == usuario.Contraseña && t.Estado == "AC");
        }


        public Respuesta<Usuario> Guardar(Usuario usuario)
        {
            try
            {
                Context.Usuarios.Add(usuario);
                Context.SaveChanges();
                return new Respuesta<Usuario>(usuario);
            }
            catch (Exception e)
            {
                return new Respuesta<Usuario>($"Error de la aplicacion: {e.Message}");
            }
        }
    }
}
