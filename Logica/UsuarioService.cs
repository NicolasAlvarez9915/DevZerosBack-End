using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            return Context.Usuarios.FirstOrDefault(t => t.Correo == usuario.Correo && t.Contraseña == Hash.GetSha256(usuario.Contraseña) && t.Estado == "AC");
        }


        public Respuesta<Usuario> Guardar(Usuario usuario)
        {
            try
            {
                usuario.Contraseña = Hash.GetSha256(usuario.Contraseña);
                Context.Usuarios.Add(usuario);
                Context.SaveChanges();
                return new Respuesta<Usuario>(usuario);
            }
            catch (Exception e)
            {
                return new Respuesta<Usuario>($"Error de la aplicacion: {e.Message}");
            }
        }

        public Respuesta<Usuario> Buscar(string correo)
        {
            Usuario usuario = Context.Usuarios.FirstOrDefault(c => c.Correo == correo);
            if (usuario != null) return new Respuesta<Usuario>(usuario);
            return new Respuesta<Usuario>("No existe");
        }

        private void ValidarUsuariosPredeterminados()
        {
            string correo = "liderAvaluos@admin.com";
            Usuario usuario = Context.Usuarios.FirstOrDefault(c => c.Correo == correo);
            if (usuario == null)
            {
                LiderAvaluo liderAvaluo = liderAvaluosService.RegistrarUsuarioPorDefecto();
                usuario = new Usuario
                {
                    Contraseña = "admin",
                    Identificacion = liderAvaluo.identificacion,
                    Correo = correo,
                    Estado = "AC",
                    Rol = "Lider Avaluos"
                };
                Guardar(usuario);
            }
            correo = "profecionalVentas@admin.com";
            usuario = Context.Usuarios.FirstOrDefault(c => c.Correo == correo);
            if (usuario == null)
            {
                ProfecionalVentas profecionalVentas = profecionalVentasService.RegistrarUsuarioPorDefecto();
                usuario = new Usuario
                {
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

    public static class Hash
    {
        public static string GetSha256(string str)
        {
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            foreach (var t in stream)
                sb.AppendFormat("{0:x2}", t);
            return sb.ToString();
        }
    }
}
