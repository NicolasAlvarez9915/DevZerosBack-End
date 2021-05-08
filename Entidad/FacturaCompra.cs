using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Entidad
{
    public class FacturaCompra: Factura
    {
        [ForeignKey("CodFactura")]
        private List<DetalleFacturaCompra> detallesFactura;
        [ForeignKey("Proveedor")]
        public string IdProveedor { get; set; }
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
        public FacturaCompra()
        {
            detallesFactura = new List<DetalleFacturaCompra>();
        }

        public DetalleFacturaCompra AgregarDetallesFactura(DispositivoMovil producto)
        {
            if (producto.Cantidad<=0)
            {
                return null;
            }
            DetalleFacturaCompra detalleFactura = new DetalleFacturaCompra(producto);
            detalleFactura.CodFactura = Codigo;
            detallesFactura.Add(detalleFactura);
            return detalleFactura;
        }
        public List<DetalleFacturaCompra> GetDetallesFactura()
        {
           return detallesFactura;

        }
    }
}
