using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiShare.Infrastructure.Migrations
{
    public partial class fixedFieldUsersCountLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLimit",
                table: "Trips",
                newName: "UsersCountLimit");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "UsersCountLimit",
                table: "Trips",
                newName: "UserLimit");
        }
    }
}
