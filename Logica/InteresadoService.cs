using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class InteresadoService
    {
        private readonly NaacCelularesContext Context;
        public InteresadoService(NaacCelularesContext Context)
        {
            this.Context = Context;
        }

        public Respuesta<Interesado> Guardar(Interesado interesado)
        {
            try
            {
                Context.Interesados.Add(interesado);
                Context.SaveChanges();
                return new Respuesta<Interesado>(interesado);
            }
            catch (Exception e)
            {
                return new Respuesta<Interesado>($"Error de la aplicacion: {e.Message}");
            }
        }
        
        public Respuesta<Interesado> Buscar(string Identificacion){
            Interesado interesado = Context.Interesados.FirstOrDefault(i => i.identificacion == Identificacion);
            if(interesado != null) return new Respuesta<Interesado>(interesado);
            return new Respuesta<Interesado>("No existe");
        }

        public List<Interesado> Todos()
        {
            List<Interesado> Interesados  = Context.Interesados.ToList();
            return Interesados;
        }

        public void ActualizarInfo(Interesado interesado)
        {
            Interesado InteresadoEncontrado = Context.Interesados.FirstOrDefault(i => i.identificacion == i.identificacion);
            if(InteresadoEncontrado.Nombres != interesado.Nombres)
            {
                InteresadoEncontrado.Nombres = interesado.Nombres;
            }
            if(InteresadoEncontrado.Apellidos != interesado.Apellidos)
            {
                InteresadoEncontrado.Apellidos = interesado.Apellidos;
            }
            if(InteresadoEncontrado.Telefono != interesado.Telefono)
            {
                InteresadoEncontrado.Telefono = interesado.Telefono;
            }
            Context.Interesados.Update(InteresadoEncontrado);
            Context.SaveChanges();
        }
    }
}
