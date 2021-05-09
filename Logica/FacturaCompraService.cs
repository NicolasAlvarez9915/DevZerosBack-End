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

        public List<FacturaCompra> buscarFacturasDispositivo(String codigo)
        {
            List<FacturaCompra> facturas = Context.FaturasCompras.Include(s => s.DetallesFactura).ToList();
            List<FacturaCompra> facturasDispositivo = new List<FacturaCompra>();
            foreach (var item in facturas)
            {
                foreach (var item1 in item.DetallesFactura)
                {
                    if(item1.CodDispositivoMovil == codigo){
                        facturasDispositivo.Add(item);
                        break;
                    }
                }
            }
            return facturasDispositivo;
        }

        public Respuesta<FacturaCompra> Guardar(FacturaCompra factura)
        {
            try
            {
                factura = InicializarCodigos(factura);
                factura.FechaFactura = DateTime.Now;
                Context.FaturasCompras.Add(factura);
                Context.SaveChanges();
                return new Respuesta<FacturaCompra>(factura);
            }
            catch (Exception e)
            {
                return new Respuesta<FacturaCompra>($"Error de la aplicacion: {e.Message}");
            }
        }



        private FacturaCompra InicializarCodigos(FacturaCompra factura)
        {
            factura.Codigo = Context.FaturasCompras.ToList().Count().ToString();
            int codigoactual = Context.DetallesFacturaCompra.ToList().Count();
            foreach (var item in factura.DetallesFactura)
            {
                item.CodFactura = factura.Codigo;
                item.Codigo = codigoactual.ToString();
                codigoactual++;
            }
            return factura;
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
