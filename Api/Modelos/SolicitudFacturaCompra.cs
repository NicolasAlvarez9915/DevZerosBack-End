using System;
using System.Collections.Generic;

namespace Api.Modelos
{
    public class SolicitudFacturaCompra
    {
        public ProveedorVista proveedor { get; set; }
        public List<DispositivoMovilEntrada> Dispositivos { get; set; }
    }
}
