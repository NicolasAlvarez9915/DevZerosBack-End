using System;
using Datos;
using Entidad;

namespace Logica
{
    public class LiderAvaluosService
    {
        private readonly LiderAvaluo liderAvaluos;
        private readonly NaacCelularesContext Context;
        public LiderAvaluosService(NaacCelularesContext Context)
        {
            this.Context = Context;
            liderAvaluos = new LiderAvaluo{
                Apellidos = "Alvarez Campuzano",
                FechaContratacion = DateTime.Now,
                identificacion = "1120754742",
                Nombres = "Nicolas Alvarez",
                Puesto = "Lider Avaluo",
                Telefono = "3017120334"
            };
        }

        public LiderAvaluo RegistrarUsuarioPorDefecto(){
            Context.LideresAvaluo.Add(liderAvaluos);
            Context.SaveChanges();
            return liderAvaluos;
        }

    }
}
