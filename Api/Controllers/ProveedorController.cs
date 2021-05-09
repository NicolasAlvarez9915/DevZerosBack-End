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
    public class ProveedorController: ControllerBase
    {
        
        private readonly ProveedorService Service;
        private JwtService JwtService { get; set; }

        public ProveedorController(NaacCelularesContext context, IOptions<AppSetting> appSettings)
        {
            JwtService = new JwtService(appSettings);
            Service = new ProveedorService(context);
        }
        
        [HttpGet("{nit}")]
        public ActionResult<ProveedorVista> Get(string nit)
        {
            var response = Service.Buscar(nit);
            if(response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new ProveedorVista(response.Objecto));
        }

        [HttpPost]
        public ActionResult<ProveedorVista> Post(ProveedorEntrada Entrada)
        {
            var Respuesta = Service.Guardar(MapearProveedor(Entrada));
            return Ok(new ProveedorVista(Respuesta.Objecto));
        }

        [HttpGet]
        public IEnumerable<ProveedorVista> Gets()
        {
            return Service.Todos().Select(p => new ProveedorVista(p));
        }

        private Proveedor MapearProveedor(ProveedorEntrada entrada)
        {
            return new Proveedor{
                Nit = entrada.Nit,
                Nombre = entrada.Nombre
            };
        }
    }
}
