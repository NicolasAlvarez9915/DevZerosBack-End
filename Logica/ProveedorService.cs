using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class ProveedorService
    {
        private readonly NaacCelularesContext Context;
        public ProveedorService(NaacCelularesContext Context)
        {
            this.Context = Context;
        }

        
        public Respuesta<Proveedor> Guardar(Proveedor proveedor)
        {
            try
            {
                Context.Proveedores.Add(proveedor);
                Context.SaveChanges();
                return new Respuesta<Proveedor>(proveedor);
            }
            catch (Exception e)
            {
                return new Respuesta<Proveedor>($"Error de la aplicacion: {e.Message}");
            }
        }
        
        public Respuesta<Proveedor> Buscar(string Identificacion){
            Proveedor proveedor = Context.Proveedores.FirstOrDefault(i => i.Nit == Identificacion);
            if(proveedor != null) return new Respuesta<Proveedor>(proveedor);
            return new Respuesta<Proveedor>("No existe");
        }

        public List<Proveedor> Todos()
        {
            List<Proveedor> Proveedores  = Context.Proveedores.ToList();
            return Proveedores;
        }
    }
}
