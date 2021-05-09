using System;
using System.Collections.Generic;
using Entidad;

namespace Api.Modelos
{
    public class FacturaCompraEntrada
    {
        public string Codigo { get; set; }
        public DateTime FechaFactura { get; set; }
        public List<DetalleFacturaCompra> DetallesFactura { get; set; }
        public string IdProveedor { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
    }

    public class FacturaCompraVista: FacturaCompra
    {
        public FacturaCompraVista()
        {

        }
        public FacturaCompraVista(FacturaCompra factura)
        {
            Codigo = factura.Codigo;
            FechaFactura = factura.FechaFactura;
            DetallesFactura = factura.DetallesFactura;
            IdProveedor = factura.IdProveedor;
            Subtotal = factura.Subtotal;
            Iva = factura.Iva;
            Descuento = factura.Descuento;
            Total = factura.Total;
        }
    }
}
