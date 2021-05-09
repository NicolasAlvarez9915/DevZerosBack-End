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
    public class FacturaVentaController: ControllerBase
    {
        private readonly FacturaVentaService Service;
        private readonly DispositivoMovilService dispositivoMovilService;
        private JwtService JwtService { get; set; }

        public FacturaVentaController(NaacCelularesContext context, IOptions<AppSetting> appSettings)
        {
            JwtService = new JwtService(appSettings);
            Service = new FacturaVentaService(context);
            dispositivoMovilService = new DispositivoMovilService(context);
        }
        [AllowAnonymous]
        [HttpPost("SolicitudFacturaVenta")]
        public ActionResult<FacturaVentaVista> GenerarFactura(SolicitudFacturaVenta solicitud)
        {
            InteresadoEntrada interesado = solicitud.Interesado;
            List<DispositivoMovilEntrada> dispositivosEntrada = solicitud.Dispositivos;
            List<DispositivoMovil> dispositivos = dispositivosEntrada.Select(p => MapearDispositivoMovil(p)).ToList();
            var respuesta = Service.generarFactura( MapearInteresado(interesado),dispositivos);
            return Ok(new FacturaVentaVista(respuesta.Objecto));
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

        [HttpPost]
        public ActionResult<FacturaVentaVista> Post(FacturaVentaEntrada Entrada)
        {
            var Respuesta = Service.Guardar(MapearFactura(Entrada));
            foreach (var item in Respuesta.Objecto.DetallesFactura)
            {
                dispositivoMovilService.RestarCantidad(item.CodDispositivoMovil, item.Cantidad);
            }
            return Ok(new FacturaVentaVista(Respuesta.Objecto));
        }

        private FacturaVenta MapearFactura(FacturaVentaEntrada entrada)
        {
            return new FacturaVenta{
                Codigo = entrada.Codigo,
                Descuento = entrada.Descuento,
                DetallesFactura = entrada.DetallesFactura,
                FechaFactura = entrada.FechaFactura,
                IdInteresado = entrada.IdInteresado,
                Iva = entrada.Iva,
                Subtotal = entrada.Subtotal,
                Total = entrada.Total
            };
        }

        [HttpGet]
        public IEnumerable<FacturaVentaVista> Gets()
        {
            return Service.Facturas().Select(p => new FacturaVentaVista(p));
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
                Imagen = null,
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
    }
}
