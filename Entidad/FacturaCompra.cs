using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class FacturaCompra : Factura
    {
        [ForeignKey("CodFactura")]
        public List<DetalleFacturaCompra> DetallesFactura { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        [ForeignKey("Proveedor")]
        public string IdProveedor { get; set; }
        [Column(TypeName = "real")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "real")]
        public decimal Iva { get; set; }
        [Column(TypeName = "real")]
        public decimal Descuento { get; set; }
        [Column(TypeName = "real")]
        public decimal Total { get; set; }
        public FacturaCompra()
        {
            DetallesFactura = new List<DetalleFacturaCompra>();
        }

        public DetalleFacturaCompra AgregarDetallesFactura(DispositivoMovil producto)
        {
            if (producto.Cantidad <= 0)
            {
                return null;
            }
            DetalleFacturaCompra detalleFactura = new DetalleFacturaCompra(producto);
            detalleFactura.CodFactura = Codigo;
            DetallesFactura.Add(detalleFactura);
            Calulartodo();
            return detalleFactura;
        }
        void Calulartodo()
        {
            Subtotal = DetallesFactura.Sum(d => d.Subtotal);
            Descuento = DetallesFactura.Sum(d => d.ValorDescuento);
            Iva = DetallesFactura.Sum(d => d.ValorIVA);
            Total = Subtotal - Descuento + Iva;
        }
    }
}