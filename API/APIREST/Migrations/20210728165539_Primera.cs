using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leccion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.IdComentario);
                });

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
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contraseña = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A67F423AE4", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "datosInstructor",
                columns: table => new
                {
                    idInstructor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estudios = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    certificacion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    experienciaLab = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cuentaBancaria = table.Column<int>(type: "int", nullable: false),
                    usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__datosIns__C96115215D1A2FF5", x => x.idInstructor);
                    table.ForeignKey(
                        name: "FK__datosInst__usuar__5AEE82B9",
                        column: x => x.usuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
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
                name: "cursos",
                columns: table => new
                {
                    idCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false),
                    idInstructor = table.Column<int>(type: "int", nullable: false),
                    duracion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cursos__8551ED054066E96A", x => x.idCurso);
                    table.ForeignKey(
                        name: "FK__cursos__idInstru__5165187F",
                        column: x => x.idInstructor,
                        principalTable: "datosInstructor",
                        principalColumn: "idInstructor",
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
                name: "Leccion",
                columns: table => new
                {
                    idLeccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enlace_video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCurso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leccion__8916A411B9590120", x => x.idLeccion);
                    table.ForeignKey(
                        name: "FK__Leccion__idCurso__160F4887",
                        column: x => x.idCurso,
                        principalTable: "cursos",
                        principalColumn: "idCurso",
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
                name: "IX_Compra_idEstudiante",
                table: "Compra",
                column: "idEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_idInstructor",
                table: "cursos",
                column: "idInstructor");

            migrationBuilder.CreateIndex(
                name: "IX_datosInstructor_usuario",
                table: "datosInstructor",
                column: "usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_idCompra",
                table: "Detalle",
                column: "idCompra");

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_idUsuario",
                table: "estudiantes",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Leccion_idCurso",
                table: "Leccion",
                column: "idCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "CuentaBancaria");

            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Leccion");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "datosInstructor");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
