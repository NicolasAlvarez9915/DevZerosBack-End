using System;
using System.Collections.Generic;
using System.Linq;
using Api.Config;
using Api.Modelos;
using Api.Service;
using Datos;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        private readonly UsuarioService Service;
        private JwtService JwtService { get; set; }

        public UsuarioController(NaacCelularesContext context,IOptions<AppSetting> appSettings)
        {
            JwtService = new JwtService(appSettings);
            Service = new UsuarioService(context);
        }

        [AllowAnonymous]
        [HttpPost("InicioSesion")]
        public ActionResult<SessionVista> Login(SessionEntrada sessionEntrada)
        {
            var user = Service.ValidarSession(MapearUsuario(sessionEntrada));
            if (user == null) return BadRequest("Username or password is incorrect");
            var response = JwtService.GenerateToken(user);
            return Ok(response);
        }

        private Usuario MapearUsuario(SessionEntrada sessionEntrada)
        {
            return new Usuario{
                Contraseña = sessionEntrada.Contrasena,
                Correo = sessionEntrada.Correo
            };
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UsuarioVista> Post(UsuarioEntrada UsuarioEntrada)
        {
            Usuario Usuario = MapearUsuario(UsuarioEntrada);
            var Respuesta = Service.Guardar(Usuario);
            return Ok(Respuesta.Objecto);
        }
        private Usuario MapearUsuario(UsuarioEntrada usuarioEntrada)
        {
            var usuario = new Usuario
            {
                Contraseña = usuarioEntrada.Contrasena,
                IdPersona = usuarioEntrada.IdPersona,
                Correo = usuarioEntrada.Correo,
                Rol = usuarioEntrada.Rol,
                Estado = usuarioEntrada.Estado
            };
            return usuario;
        }
    }
}