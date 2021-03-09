using Microsoft.EntityFrameworkCore.Migrations;

namespace apicommercialair.data.Migrations
{
    public partial class tbl_Manufacturer_About : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "Manufacturers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAbout",
                table: "Manufacturers",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyAbout",
                table: "Manufacturers");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyWebsite",
                table: "Manufacturers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
