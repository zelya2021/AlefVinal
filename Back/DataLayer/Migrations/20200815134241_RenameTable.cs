using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RenameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Directory",
                table: "Directory");

            migrationBuilder.RenameTable(
                name: "Directory",
                newName: "Codes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Codes",
                table: "Codes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Codes",
                table: "Codes");

            migrationBuilder.RenameTable(
                name: "Codes",
                newName: "Directory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directory",
                table: "Directory",
                column: "Id");
        }
    }
}
