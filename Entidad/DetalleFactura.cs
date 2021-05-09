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
        public decimal Subtotal { get; set; }
        [Column(TypeName = "real")]
        public decimal ValorDescuento { get; set; }
        [Column(TypeName = "real")]
        public decimal ValorDespuesDescuento { get; set; }
        [Column(TypeName = "real")]
        public decimal ValorIVA { get; set; }
       [Column(TypeName = "real")]
        public decimal Total{ get; set; }

        public void CalcularTodo(){
            Subtotal = ValorUnitario * Cantidad;
            ValorDescuento = Subtotal * (PorcentajeDescuento / 100);
            ValorDespuesDescuento = Subtotal -ValorDescuento;
            ValorIVA = ValorDespuesDescuento * (PorcentajeIva/100);
            Total = Subtotal-ValorDescuento+ValorIVA;
        }

        public DetalleFactura(){
            
        }
        public DetalleFactura(DispositivoMovil dispositivoMovil){
            PorcentajeDescuento = dispositivoMovil.PorcentajeDescuento;
            PorcentajeIva = dispositivoMovil.PorcentajeIva;
            Cantidad = dispositivoMovil.Cantidad;
            CalcularTodo();
        }
        
    }
}
