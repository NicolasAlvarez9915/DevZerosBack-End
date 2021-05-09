using System;
using Entidad;

namespace Api.Modelos
{
    public class ProveedorEntrada
    {
        public string Nit { get; set; }
        public string Nombre { get; set; }
    }

    public class ProveedorVista: ProveedorEntrada
    {
        public ProveedorVista()
        {

        }

        public ProveedorVista(Proveedor proveedor)
        {
            Nit = proveedor.Nit;
            Nombre = proveedor.Nombre;
        }
    }
}
