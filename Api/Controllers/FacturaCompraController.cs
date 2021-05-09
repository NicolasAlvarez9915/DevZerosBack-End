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
    public class FacturaCompraController: ControllerBase
    {
        private readonly FacturaCompraService Service;
        private JwtService JwtService { get; set; }

        public FacturaCompraController(NaacCelularesContext context, IOptions<AppSetting> appSettings)
        {
            JwtService = new JwtService(appSettings);
            Service = new FacturaCompraService(context);
        }

        [HttpGet("Dispositivo/{codigo}")]
        public IEnumerable<FacturaCompraVista> Buscar(string codigo)
        {
            return Service.buscarFacturasDispositivo(codigo).Select(p => new FacturaCompraVista(p));
        }

        [HttpPost("SolicitudFacturaCompra")]
        public ActionResult<FacturaCompraVista> GenerarFactura(SolicitudFacturaCompra solicitud)
        {
            ProveedorEntrada proveedorEntrada = solicitud.proveedor;
            List<DispositivoMovilEntrada> dispositivosEntrada = solicitud.Dispositivos;
            List<DispositivoMovil> dispositivos = dispositivosEntrada.Select(p => MapearDispositivoMovil(p)).ToList();
            var respuesta = Service.generarFactura( MapearProveedor(proveedorEntrada),dispositivos);
            return Ok(new FacturaCompraVista(respuesta.Objecto));
        }

        [HttpPost]
        public ActionResult<FacturaCompraVista> Post(FacturaCompraEntrada Entrada)
        {
            var Respuesta = Service.Guardar(MapearFactura(Entrada));
            return Ok(new FacturaCompraVista(Respuesta.Objecto));
        }

        private FacturaCompra MapearFactura(FacturaCompraEntrada entrada)
        {
            return new FacturaCompra{
                Codigo = entrada.Codigo,
                Descuento = entrada.Descuento,
                DetallesFactura = entrada.DetallesFactura,
                FechaFactura = entrada.FechaFactura,
                IdProveedor = entrada.IdProveedor,
                Iva = entrada.Iva,
                Subtotal = entrada.Subtotal,
                Total = entrada.Total
            };
        }

        [HttpGet]
        public IEnumerable<FacturaCompraVista> Gets()
        {
            return Service.Facturas().Select(p => new FacturaCompraVista(p));
        }
        private Proveedor MapearProveedor(ProveedorEntrada entrada)
        {
            return new Proveedor{
                Nit = entrada.Nit,
                Nombre = entrada.Nombre
            };
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
