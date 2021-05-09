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
    public class DispositivoMovilController : ControllerBase
    {
        private readonly DispositivoMovilService Service;
        private JwtService JwtService { get; set; }

        public DispositivoMovilController(NaacCelularesContext context, IOptions<AppSetting> appSettings)
        {
            JwtService = new JwtService(appSettings);
            Service = new DispositivoMovilService(context);
        }


        [HttpGet("{Codigo}")]
        public ActionResult<DispositivoMovilVista> Get(string codigo)
        {
            var response = Service.Buscar(codigo);
            if (response.Error)
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(new DispositivoMovilVista(response.Objecto));
        }
        [HttpPost]
        public ActionResult<DispositivoMovilVista> Post(List<DispositivoMovilEntrada> Entrada)
        {
            Respuesta<DispositivoMovil> Respuesta = new Respuesta<DispositivoMovil>("");
            foreach (var item in Entrada)
            {
                Respuesta = Service.Guardar(MapearDispositivoMovil(item)); 
            }
            return Ok(Respuesta.Objecto);
        }

        private DispositivoMovil MapearDispositivoMovil(DispositivoMovilEntrada entrada)
        {
            return new DispositivoMovil
            {
                Almacenamiento = entrada.Almacenamiento,
                Camara = entrada.Camara,
                Cantidad = entrada.Cantidad,
                CapacidadBateria = entrada.CapacidadBateria,
                Codigo = entrada.Codigo,
                Imagen = ExtraerBase64(entrada.Imagen),
                LectorHuella = entrada.LectorHuella,
                Marca =entrada.Marca,
                Modelo = entrada.Modelo,
                PorcentajeDescuento = entrada.PorcentajeDescuento,
                PorcentajeIva = entrada.PorcentajeIva,
                PrecioCompra = entrada.PrecioCompra,
                PrecioVenta = entrada.PrecioVenta,
                Procesador = entrada.Procesador,
                Ram = entrada.Ram,
                Resolucion = entrada.Resolucion,
                TipoBateria = entrada.TipoBateria,
                TipoPantalla = entrada.TipoPantalla,
                TipoProteccion = entrada.TipoProteccion
            };

        }

        private byte[] ExtraerBase64(string imagen)
        {

            string[] trozos = imagen.Split(',');

            string imagenB64 = trozos[1];
            if (trozos.Length > 2)
            {
                for (int i = 2; i >= trozos.Length - 1; i++)
                {
                    imagenB64 += ',' + trozos[i];
                }
            }

            return Convert.FromBase64String(imagenB64);
        }

        [HttpPut("Actualizar")]
        public ActionResult<String> Put(DispositivoMovilEntrada Entrada)
        {
            Service.Abastecer(MapearDispositivoMovil(Entrada));
            return Ok("Correcto");
        }

        [HttpGet]
        public IEnumerable<DispositivoMovilVista> Gets()
        {
            return Service.Todos().Select(p => new DispositivoMovilVista(p));
        }

    }
}
