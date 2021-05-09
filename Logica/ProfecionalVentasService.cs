using System;
using Datos;
using Entidad;

namespace Logica
{

    public class ProfecionalVentasService
    {
        private readonly ProfecionalVentas profecionalVentas;
        private readonly NaacCelularesContext Context;
        public ProfecionalVentasService(NaacCelularesContext Context)
        {
            this.Context = Context;
            profecionalVentas = new ProfecionalVentas{
                Apellidos = "Alvarez Campuzano",
                FechaContratacion = DateTime.Now,
                identificacion = "1120754743",
                Nombres = "Naac Alvarez",
                Puesto = "Profecional Ventas",
                Telefono = "3017120333"
            };
        }

        public ProfecionalVentas RegistrarUsuarioPorDefecto(){
            Context.ProfecionalesVentas.Add(profecionalVentas);
            Context.SaveChanges();
            return profecionalVentas;
        }
    }
}
