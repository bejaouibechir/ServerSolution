using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infra.SqlServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    DaysOff = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Departement",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    History = table.Column<string>(type: "xml", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Employee",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_EmployeeID",
                table: "Client",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartementId",
                table: "Employee",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ClientId",
                table: "Invoice",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Departement");
        }
    }
}
