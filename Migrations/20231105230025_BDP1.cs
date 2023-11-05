using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoP1_final.Migrations
{
    public partial class BDP1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionID);
                });

            migrationBuilder.CreateTable(
                name: "Huesped",
                columns: table => new
                {
                    HuespedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHuesped = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huesped", x => x.HuespedID);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HabitacionID = table.Column<int>(type: "int", nullable: false),
                    HuespedID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserva_Habitacion_HabitacionID",
                        column: x => x.HabitacionID,
                        principalTable: "Habitacion",
                        principalColumn: "HabitacionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Huesped_HuespedID",
                        column: x => x.HuespedID,
                        principalTable: "Huesped",
                        principalColumn: "HuespedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HabitacionID",
                table: "Reserva",
                column: "HabitacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_HuespedID",
                table: "Reserva",
                column: "HuespedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Huesped");
        }
    }
}
