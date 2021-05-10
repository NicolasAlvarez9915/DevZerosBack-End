using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DispositivosMoviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(11)", nullable: true),
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
                    LectorHuella = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositivosMoviles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturasVentas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInteresado = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Iva = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
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
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    Iva = table.Column<float>(type: "real", nullable: false),
                    Descuento = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "Date", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LideresAvaluo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puesto = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "Date", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LideresAvaluo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfecionalesVentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puesto = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "Date", nullable: false),
                    identificacion = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfecionalesVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaVenta",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodDispositivoMovil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcentajeIva = table.Column<float>(type: "real", nullable: false),
                    PorcentajeDescuento = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    CodFactura = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    ValorDespuesDescuento = table.Column<float>(type: "real", nullable: false),
                    ValorIVA = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaVenta", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVenta_FacturasVentas_CodFactura",
                        column: x => x.CodFactura,
                        principalTable: "FacturasVentas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaCompra",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodDispositivoMovil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcentajeIva = table.Column<float>(type: "real", nullable: false),
                    PorcentajeDescuento = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    CodFactura = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    ValorDespuesDescuento = table.Column<float>(type: "real", nullable: false),
                    ValorIVA = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaCompra", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaCompra_FaturasCompras_CodFactura",
                        column: x => x.CodFactura,
                        principalTable: "FaturasCompras",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaCompra_CodFactura",
                table: "DetallesFacturaCompra",
                column: "CodFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVenta_CodFactura",
                table: "DetallesFacturaVenta",
                column: "CodFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DispositivosMoviles_Codigo",
                table: "DispositivosMoviles",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Interesados_identificacion",
                table: "Interesados",
                column: "identificacion",
                unique: true,
                filter: "[identificacion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LideresAvaluo_identificacion",
                table: "LideresAvaluo",
                column: "identificacion",
                unique: true,
                filter: "[identificacion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfecionalesVentas_identificacion",
                table: "ProfecionalesVentas",
                column: "identificacion",
                unique: true,
                filter: "[identificacion] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true,
                filter: "[Correo] IS NOT NULL");
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
                name: "Interesados");

            migrationBuilder.DropTable(
                name: "LideresAvaluo");

            migrationBuilder.DropTable(
                name: "ProfecionalesVentas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "FaturasCompras");

            migrationBuilder.DropTable(
                name: "FacturasVentas");
        }
    }
}
