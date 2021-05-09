using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class FacturaVenta: Factura
    {
        [ForeignKey("CodFactura")]
        public List<DetalleFacturaVenta> DetallesFactura  { get; set; }
        [ForeignKey("Interesado")]
        [Column(TypeName = "nvarchar(11)")]
        public string IdInteresado { get; set; }
        [Column(TypeName = "real")]
        public decimal Subtotal { get; set; }
        [Column(TypeName = "real")]
        public decimal Iva  { get; set; }
        [Column(TypeName = "real")]
        public decimal Descuento { get; set; }
        [Column(TypeName = "real")]
        public decimal Total { get; set; }
        public FacturaVenta()
        {
            DetallesFactura = new List<DetalleFacturaVenta>();
        }

        public DetalleFacturaVenta AgregarDetallesFactura(DispositivoMovil producto)
        {
            if (producto.Cantidad<=0)
            {
                return null;
            }
            DetalleFacturaVenta detalleFactura = new DetalleFacturaVenta(producto);
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

        public List<DetalleFacturaVenta> GetDetallesFactura()
        {
           return DetallesFactura;

        }
    }
}
