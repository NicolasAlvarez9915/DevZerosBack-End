using System;

namespace Entidad
{
    public class DetalleFacturaCompra: DetalleFactura
    {
        public DetalleFacturaCompra(){}
        public DetalleFacturaCompra(DispositivoMovil dispositivoMovil) 
        {
            ValorUnitario = dispositivoMovil.PrecioCompra;
            PorcentajeDescuento = dispositivoMovil.PorcentajeDescuento;
            PorcentajeIva = dispositivoMovil.PorcentajeIva;
            Cantidad = dispositivoMovil.Cantidad;
        }
    }
}
