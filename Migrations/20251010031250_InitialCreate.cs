using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITEquipmentBorrowApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Requester_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Requester_Email = table.Column<string>(type: "TEXT", nullable: false),
                    Requester_Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Requester_Role = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentType = table.Column<string>(type: "TEXT", nullable: false),
                    RequestDetails = table.Column<string>(type: "TEXT", nullable: false),
                    Borrow_DurationDays = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
