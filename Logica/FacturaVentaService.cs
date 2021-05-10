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
           List<DetalleFacturaVenta> DetallesFacturaVenta = factura.DetallesFactura;
            factura.DetallesFactura = null;
            using (var DbTransaccion = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.FacturasVentas.Add(factura);
                    Context.SaveChanges();
                    FacturaVenta facturaEncontrada = Context.FacturasVentas.ToList()[Context.FacturasVentas.ToList().Count()-1];
                    foreach (var item in DetallesFacturaVenta)
                    {
                        item.CodFactura = facturaEncontrada.Codigo;
                        Context.DetallesFacturaVenta.Add(item);
                    }
                    Context.SaveChanges();
                    return new Respuesta<FacturaVenta>(factura);
                }
                catch (Exception e)
                {
                    DbTransaccion.Rollback();
                    return new Respuesta<FacturaVenta>($"Error de la aplicacion: {e.Message}");
                }
            }
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

