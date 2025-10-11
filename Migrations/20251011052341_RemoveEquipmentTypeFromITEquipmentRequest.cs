using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITEquipmentBorrowApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEquipmentTypeFromITEquipmentRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "Requests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EquipmentType",
                table: "Requests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
