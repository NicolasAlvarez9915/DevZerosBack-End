using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class avance7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdProveedor",
                table: "FaturasCompras",
                type: "nvarchar(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Descuento",
                table: "FaturasCompras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Iva",
                table: "FaturasCompras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Subtotal",
                table: "FaturasCompras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "FaturasCompras",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "IdInteresado",
                table: "FacturasVentas",
                type: "nvarchar(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Descuento",
                table: "FacturasVentas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Iva",
                table: "FacturasVentas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Subtotal",
                table: "FacturasVentas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "FacturasVentas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "DispositivosMoviles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Subtotal",
                table: "DetallesFacturaVenta",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "DetallesFacturaVenta",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorDescuento",
                table: "DetallesFacturaVenta",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorDespuesDescuento",
                table: "DetallesFacturaVenta",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorIVA",
                table: "DetallesFacturaVenta",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Subtotal",
                table: "DetallesFacturaCompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Total",
                table: "DetallesFacturaCompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorDescuento",
                table: "DetallesFacturaCompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorDespuesDescuento",
                table: "DetallesFacturaCompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorIVA",
                table: "DetallesFacturaCompra",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVenta_CodFactura",
                table: "DetallesFacturaVenta",
                column: "CodFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaCompra_CodFactura",
                table: "DetallesFacturaCompra",
                column: "CodFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFacturaCompra_FaturasCompras_CodFactura",
                table: "DetallesFacturaCompra",
                column: "CodFactura",
                principalTable: "FaturasCompras",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesFacturaVenta_FacturasVentas_CodFactura",
                table: "DetallesFacturaVenta",
                column: "CodFactura",
                principalTable: "FacturasVentas",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFacturaCompra_FaturasCompras_CodFactura",
                table: "DetallesFacturaCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesFacturaVenta_FacturasVentas_CodFactura",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropIndex(
                name: "IX_DetallesFacturaVenta_CodFactura",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropIndex(
                name: "IX_DetallesFacturaCompra_CodFactura",
                table: "DetallesFacturaCompra");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "FaturasCompras");

            migrationBuilder.DropColumn(
                name: "Iva",
                table: "FaturasCompras");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "FaturasCompras");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "FaturasCompras");

            migrationBuilder.DropColumn(
                name: "Descuento",
                table: "FacturasVentas");

            migrationBuilder.DropColumn(
                name: "Iva",
                table: "FacturasVentas");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "FacturasVentas");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "FacturasVentas");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "DispositivosMoviles");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropColumn(
                name: "ValorDescuento",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropColumn(
                name: "ValorDespuesDescuento",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropColumn(
                name: "ValorIVA",
                table: "DetallesFacturaVenta");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "DetallesFacturaCompra");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "DetallesFacturaCompra");

            migrationBuilder.DropColumn(
                name: "ValorDescuento",
                table: "DetallesFacturaCompra");

            migrationBuilder.DropColumn(
                name: "ValorDespuesDescuento",
                table: "DetallesFacturaCompra");

            migrationBuilder.DropColumn(
                name: "ValorIVA",
                table: "DetallesFacturaCompra");

            migrationBuilder.AlterColumn<string>(
                name: "IdProveedor",
                table: "FaturasCompras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdInteresado",
                table: "FacturasVentas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldNullable: true);
        }
    }
}
