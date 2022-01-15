using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiShare.Infrastructure.Migrations
{
    public partial class addClosedDateToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Closed",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Trips");
        }
    }
}
