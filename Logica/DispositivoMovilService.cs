using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;

namespace Logica
{
    public class DispositivoMovilService
    {
        private readonly NaacCelularesContext Context;
        public DispositivoMovilService(NaacCelularesContext Context)
        {
            this.Context = Context;
        }

        public Respuesta<DispositivoMovil> Guardar(DispositivoMovil dispositivo)
        {
            try
            {
                DispositivoMovil dispositivoEncontrado = Context.DispositivosMoviles.Find(dispositivo.Codigo);
                if (dispositivoEncontrado == null)
                {
                    Context.DispositivosMoviles.Add(dispositivo);
                    Context.SaveChanges();
                }
                else
                {
                    Abastecer(dispositivo);
                }
                return new Respuesta<DispositivoMovil>(dispositivo);
            }
            catch (Exception e)
            {
                return new Respuesta<DispositivoMovil>($"Error de la aplicacion: {e.Message}");
            }
        }

        public void Abastecer(DispositivoMovil dispositivo)
        {
            DispositivoMovil dispositivoEncontrado = Context.DispositivosMoviles.Find(dispositivo.Codigo);
            dispositivoEncontrado.PorcentajeIva = dispositivo.PorcentajeIva;
            dispositivoEncontrado.PrecioCompra = dispositivo.PrecioVenta;
            dispositivoEncontrado.Cantidad += dispositivo.Cantidad;
            Context.DispositivosMoviles.Update(dispositivoEncontrado);
            Context.SaveChanges();
        }

        public void RestarCantidad(string codigo, int Cantidad)
        {
            DispositivoMovil dispositivoEncontrado = Context.DispositivosMoviles.Find(codigo);
            dispositivoEncontrado.Cantidad -= Cantidad;
            Context.DispositivosMoviles.Update(dispositivoEncontrado);
            Context.SaveChanges();
        }

        public Respuesta<DispositivoMovil> Buscar(string Codigo)
        {
            DispositivoMovil dispositivoMovil = Context.DispositivosMoviles.Find(Codigo);
            if (dispositivoMovil != null) return new Respuesta<DispositivoMovil>(dispositivoMovil);
            return new Respuesta<DispositivoMovil>("No existe");
        }

        public List<DispositivoMovil> Todos()
        {
            List<DispositivoMovil> DispositivosMoviles = Context.DispositivosMoviles.ToList();
            return DispositivosMoviles;
        }
    }
}
