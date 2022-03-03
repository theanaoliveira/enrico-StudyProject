using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyProject.Infrastructure.Migrations
{
    public partial class IncluindoSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Endereco",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "public");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Endereco",
                schema: "public",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "public",
                newName: "Customer");
        }
    }
}
