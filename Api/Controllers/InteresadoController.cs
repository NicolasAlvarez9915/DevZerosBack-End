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
    public class InteresadoController : ControllerBase
    {

        private readonly InteresadoService Service;
        private JwtService JwtService { get; set; }

        public InteresadoController(NaacCelularesContext context, IOptions<AppSetting> appSettings)
        {
            JwtService = new JwtService(appSettings);
            Service = new InteresadoService(context);
        }

        [HttpGet("{identificacion}")]
        public ActionResult<InteresadoVista> Get(string identificacion)
        {
            var response = Service.Buscar(identificacion);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Objecto);
        }

        [HttpPost]
        public ActionResult<InteresadoVista> Post(InteresadoEntrada Entrada)
        {
            var Respuesta = Service.Guardar(MapearInteresado(Entrada));
            return Ok(Respuesta.Objecto);
        }

        [HttpPut("Actualizar")]
        public ActionResult<String> Put(InteresadoEntrada Entrada)
        {
            Service.ActualizarInfo(MapearInteresado(Entrada));
            return Ok("Correcto");
        }

        [HttpGet]
        public IEnumerable<InteresadoVista> Gets()
        {
            return Service.Todos().Select(p => new InteresadoVista(p));
        }
        private Interesado MapearInteresado(InteresadoEntrada entrada)
        {
            return new Interesado
            {
                Apellidos = entrada.Apellidos,
                FechaRegistro = entrada.FechaRegistro,
                identificacion = entrada.identificacion,
                Nombres = entrada.Nombres,
                Telefono = entrada.Telefono
            };
        }
    }
}
