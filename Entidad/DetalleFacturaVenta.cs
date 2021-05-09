using System;

namespace Entidad
{
    public class DetalleFacturaVenta: DetalleFactura
    {   
        public DetalleFacturaVenta(){}
        public DetalleFacturaVenta(DispositivoMovil dispositivoMovil) : base(dispositivoMovil)
        {
            ValorUnitario = dispositivoMovil.PrecioVenta;
            CalcularTodo();
        }
    }
}
