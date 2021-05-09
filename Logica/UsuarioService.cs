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
        private readonly LiderAvaluosService liderAvaluosService;
        private readonly ProfecionalVentasService profecionalVentasService;
        public UsuarioService(NaacCelularesContext Context)
        {
            this.Context = Context;
            liderAvaluosService = new LiderAvaluosService(Context);
            profecionalVentasService = new ProfecionalVentasService(Context);
            ValidarUsuariosPredeterminados();
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

        public Respuesta<Usuario> Buscar(string correo){
            Usuario usuario = Context.Usuarios.Find(correo);
            if(usuario != null) return new Respuesta<Usuario>(usuario);
            return new Respuesta<Usuario>("No existe");
        }

        private void ValidarUsuariosPredeterminados(){
            string correo = "liderAvaluos@admin.com";
            Usuario usuario = Context.Usuarios.Find(correo);
            if (usuario == null)
            {
                LiderAvaluo liderAvaluo = liderAvaluosService.RegistrarUsuarioPorDefecto();
                usuario = new Usuario{
                    Contraseña = "admin",
                    Identificacion = liderAvaluo.identificacion,
                    Correo = correo,
                    Estado = "AC",
                    Rol = "Lider Avaluos"
                };
                Guardar(usuario);
            }
            correo = "profecionalVentas@admin.com";
            usuario = Context.Usuarios.Find(correo);
            if (usuario == null)
            {
                ProfecionalVentas profecionalVentas = profecionalVentasService.RegistrarUsuarioPorDefecto();
                usuario = new Usuario{
                    Contraseña = "admin",
                    Identificacion = profecionalVentas.identificacion,
                    Correo = correo,
                    Estado = "AC",
                    Rol = "Profecional Ventas"
                };
                Guardar(usuario);
            }
                
        }
    }
}
