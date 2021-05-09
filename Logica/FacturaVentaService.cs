using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class FacturaVentaService
    {
        private readonly NaacCelularesContext Context;
        public FacturaVentaService(NaacCelularesContext Context)
        {
            this.Context = Context;
        }

        public List<FacturaVenta> Facturas()
        {
            return Context.FacturasVentas.ToList();
        }

        public Respuesta<FacturaVenta> Guardar(FacturaVenta factura)
        {
            try
            {
                factura = InicializarCodigos(factura);
                factura.FechaFactura = DateTime.Now;
                Context.FacturasVentas.Add(factura);
                Context.SaveChanges();
                return new Respuesta<FacturaVenta>(factura);
            }
            catch (Exception e)
            {
                return new Respuesta<FacturaVenta>($"Error de la aplicacion: {e.Message}");
            }
        }

        private FacturaVenta InicializarCodigos(FacturaVenta factura)
        {
            factura.Codigo = Context.FacturasVentas.ToList().Count().ToString();
            int codigoactual = Context.DetallesFacturaVenta.ToList().Count();
            foreach (var item in factura.DetallesFactura)
            {
                item.CodFactura = factura.Codigo;
                item.Codigo = codigoactual.ToString();
                codigoactual++;
            }
            return factura;
        }

        public Respuesta<FacturaVenta> generarFactura(Interesado interesado, List<DispositivoMovil> dispositivos)
        {
            FacturaVenta factura = new FacturaVenta();
            foreach (var item in dispositivos)
            {
                factura.AgregarDetallesFactura(item);
            }
            factura.IdInteresado = interesado.identificacion;
            return new Respuesta<FacturaVenta>(factura);
        }
    }
}
