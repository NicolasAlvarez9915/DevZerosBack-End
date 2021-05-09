using System;
using System.Collections.Generic;

namespace Api.Modelos
{
    public class SolicitudFacturaVenta
    {
        public InteresadoEntrada Interesado { get; set; }
        public List<DispositivoMovilEntrada> Dispositivos { get; set; }
    }
}
