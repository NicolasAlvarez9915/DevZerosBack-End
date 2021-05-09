using System;

namespace Entidad
{
    public class DetalleFacturaCompra: DetalleFactura
    {
        public DetalleFacturaCompra(){}
        public DetalleFacturaCompra(DispositivoMovil dispositivoMovil) : base(dispositivoMovil)
        {
            ValorUnitario = dispositivoMovil.PrecioCompra;
            CalcularTodo();
        }
    }
}
