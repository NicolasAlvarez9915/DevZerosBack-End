using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class FacturaCompraService
    {
        private readonly NaacCelularesContext Context;
        public FacturaCompraService(NaacCelularesContext Context)
        {
            this.Context = Context;
        }

        public List<FacturaCompra> Facturas()
        {
            return Context.FaturasCompras.ToList();
        }

        public List<FacturaCompra> buscarFacturasDispositivo(string codigo)
        {
            List<FacturaCompra> facturas = Context.FaturasCompras.Include(s => s.DetallesFactura).ToList();
            List<FacturaCompra> facturasDispositivo = new List<FacturaCompra>();
            foreach (var item in facturas)
            {
                foreach (var item1 in item.DetallesFactura)
                {
                    if (item1.CodDispositivoMovil == codigo)
                    {
                        facturasDispositivo.Add(item);
                        break;
                    }
                }
            }
            return facturasDispositivo;
        }

        public Respuesta<FacturaCompra> Guardar(FacturaCompra factura)
        {
            List<DetalleFacturaCompra> DetallesFacturaCompras = factura.DetallesFactura;
            factura.DetallesFactura = null;
            using (var DbTransaccion = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.FaturasCompras.Add(factura);
                    Context.SaveChanges();
                    FacturaCompra facturaEncontrada = Context.FaturasCompras.ToList()[Context.FaturasCompras.ToList().Count()-1];
                    foreach (var item in DetallesFacturaCompras)
                    {
                        item.CodFactura = facturaEncontrada.Codigo;
                        Context.DetallesFacturaCompra.Add(item);
                    }
                    Context.SaveChanges();
                    return new Respuesta<FacturaCompra>(factura);
                }
                catch (Exception e)
                {
                    DbTransaccion.Rollback();
                    return new Respuesta<FacturaCompra>($"Error de la aplicacion: {e.Message}");
                }
            }
        }

        public Respuesta<FacturaCompra> generarFactura(Proveedor proveeedor, List<DispositivoMovil> dispositivos)
        {
            FacturaCompra factura = new FacturaCompra();
            foreach (var item in dispositivos)
            {
                factura.AgregarDetallesFactura(item);
            }
            factura.IdProveedor = proveeedor.Nit;
            return new Respuesta<FacturaCompra>(factura);
        }
    }
}
