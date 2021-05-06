using System;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class NaacCelularesContext: DbContext
    {
        public NaacCelularesContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
