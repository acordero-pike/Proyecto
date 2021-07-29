using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Respuesta",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Respuesta",
                table: "Comentarios");
        }
    }
}
