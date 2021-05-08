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
        public DbSet<FacturaCompra> FaturasCompras { get; set; }
        public DbSet<FacturaVenta> FacturasVentas { get; set; }
        public DbSet<DetalleFacturaCompra> DetallesFacturaCompra { get; set; }
        public DbSet<DetalleFacturaVenta> DetallesFacturaVenta { get; set; }
        public DbSet<Interesado> Interesados { get; set; }
        public DbSet<LiderAvaluo> LideresAvaluo { get; set; }
        public DbSet<ProfecionalVentas> ProfecionalesVentas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<DispositivoMovil> DispositivosMoviles { get; set; }
    }
}
