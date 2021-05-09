﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(NaacCelularesContext))]
    partial class NaacCelularesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.DetalleFacturaCompra", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodDispositivoMovil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodFactura")
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("PorcentajeDescuento")
                        .HasColumnType("real");

                    b.Property<float>("PorcentajeIva")
                        .HasColumnType("real");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<float>("ValorDescuento")
                        .HasColumnType("real");

                    b.Property<float>("ValorDespuesDescuento")
                        .HasColumnType("real");

                    b.Property<float>("ValorIVA")
                        .HasColumnType("real");

                    b.Property<float>("ValorUnitario")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.HasIndex("CodFactura");

                    b.ToTable("DetallesFacturaCompra");
                });

            modelBuilder.Entity("Entidad.DetalleFacturaVenta", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodDispositivoMovil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodFactura")
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("PorcentajeDescuento")
                        .HasColumnType("real");

                    b.Property<float>("PorcentajeIva")
                        .HasColumnType("real");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<float>("ValorDescuento")
                        .HasColumnType("real");

                    b.Property<float>("ValorDespuesDescuento")
                        .HasColumnType("real");

                    b.Property<float>("ValorIVA")
                        .HasColumnType("real");

                    b.Property<float>("ValorUnitario")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.HasIndex("CodFactura");

                    b.ToTable("DetallesFacturaVenta");
                });

            modelBuilder.Entity("Entidad.DispositivoMovil", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Almacenamiento")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Camara")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CapacidadBateria")
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LectorHuella")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("PorcentajeDescuento")
                        .HasColumnType("real");

                    b.Property<float>("PorcentajeIva")
                        .HasColumnType("real");

                    b.Property<float>("PrecioCompra")
                        .HasColumnType("real");

                    b.Property<float>("PrecioVenta")
                        .HasColumnType("real");

                    b.Property<string>("Procesador")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Resolucion")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TipoBateria")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TipoPantalla")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TipoProteccion")
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Codigo");

                    b.ToTable("DispositivosMoviles");
                });

            modelBuilder.Entity("Entidad.FacturaCompra", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("Date");

                    b.Property<string>("IdProveedor")
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("Iva")
                        .HasColumnType("real");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.ToTable("FaturasCompras");
                });

            modelBuilder.Entity("Entidad.FacturaVenta", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<DateTime>("FechaFactura")
                        .HasColumnType("Date");

                    b.Property<string>("IdInteresado")
                        .HasColumnType("nvarchar(11)");

                    b.Property<float>("Iva")
                        .HasColumnType("real");

                    b.Property<float>("Subtotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Codigo");

                    b.ToTable("FacturasVentas");
                });

            modelBuilder.Entity("Entidad.Interesado", b =>
                {
                    b.Property<string>("identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("Date");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("identificacion");

                    b.ToTable("Interesados");
                });

            modelBuilder.Entity("Entidad.LiderAvaluo", b =>
                {
                    b.Property<string>("identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("Date");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Puesto")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("identificacion");

                    b.ToTable("LideresAvaluo");
                });

            modelBuilder.Entity("Entidad.ProfecionalVentas", b =>
                {
                    b.Property<string>("identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaContratacion")
                        .HasColumnType("Date");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Puesto")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("identificacion");

                    b.ToTable("ProfecionalesVentas");
                });

            modelBuilder.Entity("Entidad.Proveedor", b =>
                {
                    b.Property<string>("Nit")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Nit");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Correo");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entidad.DetalleFacturaCompra", b =>
                {
                    b.HasOne("Entidad.FacturaCompra", null)
                        .WithMany("DetallesFactura")
                        .HasForeignKey("CodFactura");
                });

            modelBuilder.Entity("Entidad.DetalleFacturaVenta", b =>
                {
                    b.HasOne("Entidad.FacturaVenta", null)
                        .WithMany("DetallesFactura")
                        .HasForeignKey("CodFactura");
                });

            modelBuilder.Entity("Entidad.FacturaCompra", b =>
                {
                    b.Navigation("DetallesFactura");
                });

            modelBuilder.Entity("Entidad.FacturaVenta", b =>
                {
                    b.Navigation("DetallesFactura");
                });
#pragma warning restore 612, 618
        }
    }
}
