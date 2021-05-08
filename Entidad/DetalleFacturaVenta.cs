using System;

namespace Entidad
{
    public class DetalleFacturaVenta: DetalleFactura
    {   
        public DetalleFacturaVenta(){}
        public DetalleFacturaVenta(DispositivoMovil dispositivoMovil)
        {
            ValorUnitario = dispositivoMovil.PrecioVenta;
            PorcentajeDescuento = dispositivoMovil.PorcentajeDescuento;
            PorcentajeIva = dispositivoMovil.PorcentajeIva;
            Cantidad = dispositivoMovil.Cantidad;
        }
    }
}
