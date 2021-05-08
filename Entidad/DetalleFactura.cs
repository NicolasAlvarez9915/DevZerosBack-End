using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class DetalleFactura
    {
        [Key]
        [Column(TypeName = "nvarchar(11)")]
        public string Codigo { get; set; }
        [ForeignKey("DispositivoMovil")]
        public string CodDispositivoMovil { get; set; }
        [Column(TypeName = "real")]
        public decimal PorcentajeIva { get; set; }
        [Column(TypeName = "real")]
        public decimal PorcentajeDescuento { get; set; }
        [Column(TypeName = "int")]
        public int Cantidad { get; set; }
        [Column(TypeName = "real")]
        public decimal ValorUnitario { get; set; }
        [Column(TypeName = "nvarchar(11)")]
        public string CodFactura { get; set; }
        [Column(TypeName = "real")]
        public decimal Subtotal
        {
            get
            {
                return ValorUnitario * Cantidad;
            }
        }
        [Column(TypeName = "real")]
        public decimal ValorDescuento
        {
            get
            {
                return Subtotal * (PorcentajeDescuento / 100);
            }
        }
        [Column(TypeName = "real")]
        public decimal ValorDespuesDescuento
        {
            get
            {
                return Subtotal -ValorDescuento;
            }
        }
        [Column(TypeName = "real")]
        public decimal ValorIVA
        {
            get
            {
                return ValorDespuesDescuento * (PorcentajeIva/100);
            }
        }
       [Column(TypeName = "real")]
        public decimal Total
        { 
            get 
            {
                return Subtotal-ValorDescuento+ValorIVA;
            }
        }
        
    }
}
