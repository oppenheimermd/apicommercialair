using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apicommercialair.data.Migrations
{
    public partial class TBL_Aircraft_Flightcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FirstFlight",
                table: "Aircraft",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Introduction",
                table: "Aircraft",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstFlight",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Aircraft");
        }
    }
}
