using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Prestamos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ganancia = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: true),
                    Retrazos = table.Column<int>(type: "INTEGER", nullable: false),
                    Accesibilidad = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosMeses",
                columns: table => new
                {
                    PrestamoMesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Prestamo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Interes = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CapitalRestante = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReditoPagar = table.Column<decimal>(type: "TEXT", nullable: false),
                    DeudaRedito = table.Column<decimal>(type: "TEXT", nullable: false),
                    Ganancia = table.Column<decimal>(type: "TEXT", nullable: false),
                    Retrazo = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioIdCreacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Accesibilidad = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosMeses", x => x.PrestamoMesId);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosSemanas",
                columns: table => new
                {
                    PrestamoSemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Prestamo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Interes = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Capital = table.Column<decimal>(type: "TEXT", nullable: false),
                    Redito = table.Column<decimal>(type: "TEXT", nullable: false),
                    PagoSemanal = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalRestante = table.Column<decimal>(type: "TEXT", nullable: false),
                    CuotasRestantes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ganancia = table.Column<decimal>(type: "TEXT", nullable: false),
                    Retrazo = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioIdCreacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Accesibilidad = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosSemanas", x => x.PrestamoSemId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    NombreUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    Clave = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CodigoRecuperacion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioIdCreacion = table.Column<int>(type: "INTEGER", nullable: false),
                    Accesibilidad = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosMesesDetalle",
                columns: table => new
                {
                    PrestamoMesDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrestamoMesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroCuota = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DescripcionPago = table.Column<string>(type: "TEXT", nullable: true),
                    Abono = table.Column<decimal>(type: "TEXT", nullable: false),
                    Redito = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mora = table.Column<decimal>(type: "TEXT", nullable: false),
                    BalanceRestante = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosMesesDetalle", x => x.PrestamoMesDetalleId);
                    table.ForeignKey(
                        name: "FK_PrestamosMesesDetalle_PrestamosMeses_PrestamoMesId",
                        column: x => x.PrestamoMesId,
                        principalTable: "PrestamosMeses",
                        principalColumn: "PrestamoMesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrestamosSemanasDetalle",
                columns: table => new
                {
                    PrestamoSemDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrestamoSemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroCuota = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DescripcionPago = table.Column<string>(type: "TEXT", nullable: true),
                    Pago = table.Column<decimal>(type: "TEXT", nullable: false),
                    Mora = table.Column<decimal>(type: "TEXT", nullable: false),
                    BalanceRestante = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestamosSemanasDetalle", x => x.PrestamoSemDetalleId);
                    table.ForeignKey(
                        name: "FK_PrestamosSemanasDetalle_PrestamosSemanas_PrestamoSemId",
                        column: x => x.PrestamoSemId,
                        principalTable: "PrestamosSemanas",
                        principalColumn: "PrestamoSemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Accesibilidad", "Clave", "CodigoRecuperacion", "Email", "Fecha", "FechaCreacion", "FechaModificacion", "NombreUsuario", "Nombres", "UsuarioIdCreacion" },
                values: new object[] { 1, true, "YQBkAG0AaQBuAA==", "12345678", "Admin@outlook.com", new DateTime(2021, 1, 29, 19, 10, 7, 911, DateTimeKind.Local).AddTicks(6032), new DateTime(2021, 1, 29, 19, 10, 7, 912, DateTimeKind.Local).AddTicks(712), new DateTime(2021, 1, 29, 19, 10, 7, 912, DateTimeKind.Local).AddTicks(742), "admin", "Administrador", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosMesesDetalle_PrestamoMesId",
                table: "PrestamosMesesDetalle",
                column: "PrestamoMesId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestamosSemanasDetalle_PrestamoSemId",
                table: "PrestamosSemanasDetalle",
                column: "PrestamoSemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "PrestamosMesesDetalle");

            migrationBuilder.DropTable(
                name: "PrestamosSemanasDetalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "PrestamosMeses");

            migrationBuilder.DropTable(
                name: "PrestamosSemanas");
        }
    }
}
