using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class FacturaVenta: Factura
    {
        [ForeignKey("CodFactura")]
        private List<DetalleFacturaVenta> detallesFactura;
        [ForeignKey("Interesado")]
        public string IdInteresado { get; set; }
        [Column(TypeName = "real")]
        public decimal Subtotal
        {
            get 
            {
               return detallesFactura.Sum(d => d.Subtotal);
            }
        }
        [Column(TypeName = "real")]
        public decimal IVA
        {
            get
            {
                return detallesFactura.Sum(d => d.ValorIVA);
            }
        }
        [Column(TypeName = "real")]
        public decimal Descuento
        {
            get
            {
                return detallesFactura.Sum(d => d.ValorDescuento);
            }
        }
        [Column(TypeName = "real")]
        public decimal Total
        {
            get
            {
                return Subtotal-Descuento+IVA;
            }
        }

        public FacturaVenta()
        {
            detallesFactura = new List<DetalleFacturaVenta>();
        }

        public DetalleFacturaVenta AgregarDetallesFactura(DispositivoMovil producto)
        {
            if (producto.Cantidad<=0)
            {
                return null;
            }
            DetalleFacturaVenta detalleFactura = new DetalleFacturaVenta(producto);
            detalleFactura.CodFactura = Codigo;
            detallesFactura.Add(detalleFactura);
            return detalleFactura;

        }

        public List<DetalleFacturaVenta> GetDetallesFactura()
        {
           return detallesFactura;

        }
    }
}
