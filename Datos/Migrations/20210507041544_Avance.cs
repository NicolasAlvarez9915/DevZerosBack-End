using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class Avance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetallesFacturaCompra",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    CodDispositivoMovil = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    PorcentajeIva = table.Column<float>(type: "real", nullable: false),
                    PorcentajeDescuento = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    CodFactura = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaCompra", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaVenta",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    CodDispositivoMovil = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    PorcentajeIva = table.Column<float>(type: "real", nullable: false),
                    PorcentajeDescuento = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    CodFactura = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaVenta", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "DispositivosMoviles",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PrecioCompra = table.Column<float>(type: "real", nullable: false),
                    PrecioVenta = table.Column<float>(type: "real", nullable: false),
                    PorcentajeIva = table.Column<float>(type: "real", nullable: false),
                    PorcentajeDescuento = table.Column<float>(type: "real", nullable: false),
                    TipoPantalla = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Resolucion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Procesador = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Almacenamiento = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ram = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Camara = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TipoBateria = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CapacidadBateria = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TipoProteccion = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    LectorHuella = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositivosMoviles", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "FacturasVentas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    IdInteresado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFactura = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasVentas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "FaturasCompras",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    IdProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaFactura = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturasCompras", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Interesados",
                columns: table => new
                {
                    identificacion = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesados", x => x.identificacion);
                });

            migrationBuilder.CreateTable(
                name: "LideresAvaluo",
                columns: table => new
                {
                    identificacion = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "Date", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LideresAvaluo", x => x.identificacion);
                });

            migrationBuilder.CreateTable(
                name: "ProfecionalesVentas",
                columns: table => new
                {
                    identificacion = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "Date", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfecionalesVentas", x => x.identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Nit = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Nit);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesFacturaCompra");

            migrationBuilder.DropTable(
                name: "DetallesFacturaVenta");

            migrationBuilder.DropTable(
                name: "DispositivosMoviles");

            migrationBuilder.DropTable(
                name: "FacturasVentas");

            migrationBuilder.DropTable(
                name: "FaturasCompras");

            migrationBuilder.DropTable(
                name: "Interesados");

            migrationBuilder.DropTable(
                name: "LideresAvaluo");

            migrationBuilder.DropTable(
                name: "ProfecionalesVentas");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
