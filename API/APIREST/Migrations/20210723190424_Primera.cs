using Microsoft.EntityFrameworkCore.Migrations;

namespace APIREST.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Leccions",
                columns: table => new
                {
                    IdLeccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnlaceVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IdCursoNavigationIdCurso = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leccions", x => x.IdLeccion);
                    table.ForeignKey(
                        name: "FK_Leccions_cursos_IdCursoNavigationIdCurso",
                        column: x => x.IdCursoNavigationIdCurso,
                        principalTable: "cursos",
                        principalColumn: "idCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cursos_idInstructor",
                table: "cursos",
                column: "idInstructor");

            migrationBuilder.CreateIndex(
                name: "IX_Leccions_IdCursoNavigationIdCurso",
                table: "Leccions",
                column: "IdCursoNavigationIdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leccions");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "datosInstructor");
        }
    }
}
