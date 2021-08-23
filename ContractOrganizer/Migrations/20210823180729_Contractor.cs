using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContractOrganizer.Migrations
{
    public partial class Contractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Labour",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labour", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    labourid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Attendance_Labour_labourid",
                        column: x => x.labourid,
                        principalTable: "Labour",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    labourid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contract_Labour_labourid",
                        column: x => x.labourid,
                        principalTable: "Labour",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_labourid",
                table: "Attendance",
                column: "labourid");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_labourid",
                table: "Contract",
                column: "labourid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Labour");
        }
    }
}
