using System;
using System.Collections.Generic;
using Entidad;

namespace Api.Modelos
{
    public class FacturaVentaEntrada
    {
        public int Codigo { get; set; }
        public DateTime FechaFactura { get; set; }
        public List<DetalleFacturaVenta> DetallesFactura { get; set; }
        public string IdInteresado { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }
    public class FacturaVentaVista: FacturaVentaEntrada
    {
        public FacturaVentaVista()
        {

        }
        public FacturaVentaVista(FacturaVenta factura)
        {
            Codigo = factura.Codigo;
            FechaFactura = factura.FechaFactura;
            DetallesFactura = factura.DetallesFactura;
            IdInteresado = factura.IdInteresado;
            Subtotal = factura.Subtotal;
            Iva = factura.Iva;
            Descuento = factura.Descuento;
            Total = factura.Total;
        }
    }
}
