using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leccions_cursos_IdCursoNavigationIdCurso",
                table: "Leccions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leccions",
                table: "Leccions");

            migrationBuilder.DropIndex(
                name: "IX_Leccions_IdCursoNavigationIdCurso",
                table: "Leccions");

            migrationBuilder.DropColumn(
                name: "IdCursoNavigationIdCurso",
                table: "Leccions");

            migrationBuilder.RenameTable(
                name: "Leccions",
                newName: "Leccion");

            migrationBuilder.RenameColumn(
                name: "IdCurso",
                table: "Leccion",
                newName: "idCurso");

            migrationBuilder.RenameColumn(
                name: "IdLeccion",
                table: "Leccion",
                newName: "idLeccion");

            migrationBuilder.RenameColumn(
                name: "EnlaceVideo",
                table: "Leccion",
                newName: "Enlace_video");

            migrationBuilder.AlterColumn<int>(
                name: "idCurso",
                table: "Leccion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Leccion__8916A411B9590120",
                table: "Leccion",
                column: "idLeccion");

            migrationBuilder.CreateTable(
                name: "CuentaBancaria",
                columns: table => new
                {
                    idCuenta = table.Column<int>(type: "int", nullable: false),
                    NombreBanco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CuentaBa__BBC6DF32B8ED25D5", x => x.idCuenta);
                });

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    idEstudianes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<long>(type: "bigint", nullable: true),
                    NumTarjeta = table.Column<long>(type: "bigint", nullable: true),
                    idUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__estudian__AEFE45A63950CF98", x => x.idEstudianes);
                    table.ForeignKey(
                        name: "FK__estudiant__idUsu__6FE99F9F",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    idCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEstudiante = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    Total = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compra__48B99DB7F3620682", x => x.idCompra);
                    table.ForeignKey(
                        name: "FK__Compra__idEstudi__06CD04F7",
                        column: x => x.idEstudiante,
                        principalTable: "estudiantes",
                        principalColumn: "idEstudianes",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    CodCurso = table.Column<int>(type: "int", nullable: false),
                    idCompra = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Detalle__C648BBBF980591D1", x => new { x.CodCurso, x.idCompra });
                    table.ForeignKey(
                        name: "FK__Detalle__CodCurs__0C85DE4D",
                        column: x => x.CodCurso,
                        principalTable: "cursos",
                        principalColumn: "idCurso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Detalle__idCompr__0D7A0286",
                        column: x => x.idCompra,
                        principalTable: "Compra",
                        principalColumn: "idCompra",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_datosInstructor_usuario",
                table: "datosInstructor",
                column: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Leccion_idCurso",
                table: "Leccion",
                column: "idCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_idEstudiante",
                table: "Compra",
                column: "idEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_idCompra",
                table: "Detalle",
                column: "idCompra");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_idUsuario",
                table: "estudiantes",
                column: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK__datosInst__usuar__5AEE82B9",
                table: "datosInstructor",
                column: "usuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Leccion__idCurso__160F4887",
                table: "Leccion",
                column: "idCurso",
                principalTable: "cursos",
                principalColumn: "idCurso",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__datosInst__usuar__5AEE82B9",
                table: "datosInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK__Leccion__idCurso__160F4887",
                table: "Leccion");

            migrationBuilder.DropTable(
                name: "CuentaBancaria");

            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropIndex(
                name: "IX_datosInstructor_usuario",
                table: "datosInstructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Leccion__8916A411B9590120",
                table: "Leccion");

            migrationBuilder.DropIndex(
                name: "IX_Leccion_idCurso",
                table: "Leccion");

            migrationBuilder.RenameTable(
                name: "Leccion",
                newName: "Leccions");

            migrationBuilder.RenameColumn(
                name: "idCurso",
                table: "Leccions",
                newName: "IdCurso");

            migrationBuilder.RenameColumn(
                name: "idLeccion",
                table: "Leccions",
                newName: "IdLeccion");

            migrationBuilder.RenameColumn(
                name: "Enlace_video",
                table: "Leccions",
                newName: "EnlaceVideo");

            migrationBuilder.AlterColumn<int>(
                name: "IdCurso",
                table: "Leccions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCursoNavigationIdCurso",
                table: "Leccions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leccions",
                table: "Leccions",
                column: "IdLeccion");

            migrationBuilder.CreateIndex(
                name: "IX_Leccions_IdCursoNavigationIdCurso",
                table: "Leccions",
                column: "IdCursoNavigationIdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Leccions_cursos_IdCursoNavigationIdCurso",
                table: "Leccions",
                column: "IdCursoNavigationIdCurso",
                principalTable: "cursos",
                principalColumn: "idCurso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
