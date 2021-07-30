﻿// <auto-generated />
using System;
using APIREST.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIREST.Migrations
{
    [DbContext(typeof(ProyectocrsContext))]
    partial class ProyectocrsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

<<<<<<< HEAD
            modelBuilder.Entity("APIREST.Models.Comentario", b =>
                {
                    b.Property<int>("IdComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Leccion")
                        .HasColumnType("int");

                    b.Property<string>("Pregunta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Respuesta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComentario");

                    b.ToTable("Comentarios");
                });

=======
>>>>>>> c599edf92c8282ea0294606f0ababe80bf8cddda
            modelBuilder.Entity("APIREST.Models.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCompra")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<int?>("IdEstudiante")
                        .HasColumnType("int")
                        .HasColumnName("idEstudiante");

                    b.Property<double?>("Total")
                        .HasColumnType("float");

                    b.HasKey("IdCompra")
                        .HasName("PK__Compra__48B99DB7F3620682");

                    b.HasIndex("IdEstudiante");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("APIREST.Models.CuentaBancarium", b =>
                {
                    b.Property<int>("IdCuenta")
                        .HasColumnType("int")
                        .HasColumnName("idCuenta");

                    b.Property<string>("NombreBanco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCuenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Numero")
                        .HasColumnType("bigint");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCuenta")
                        .HasName("PK__CuentaBa__BBC6DF32B8ED25D5");

                    b.ToTable("CuentaBancaria");
                });

            modelBuilder.Entity("APIREST.Models.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCurso")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Costo")
                        .HasColumnType("float")
                        .HasColumnName("costo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("descripcion");

                    b.Property<double>("Duracion")
                        .HasColumnType("float")
                        .HasColumnName("duracion");

                    b.Property<int>("IdInstructor")
                        .HasColumnType("int")
                        .HasColumnName("idInstructor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("IdCurso")
                        .HasName("PK__cursos__8551ED054066E96A");

                    b.HasIndex("IdInstructor");

                    b.ToTable("cursos");
                });

            modelBuilder.Entity("APIREST.Models.DatosInstructor", b =>
                {
                    b.Property<int>("IdInstructor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idInstructor")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Certificacion")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("certificacion");

                    b.Property<int>("CuentaBancaria")
                        .HasColumnType("int")
                        .HasColumnName("cuentaBancaria");

                    b.Property<string>("Estudios")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("estudios");

                    b.Property<string>("ExperienciaLab")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("experienciaLab");

                    b.Property<int>("Usuario")
                        .HasColumnType("int")
                        .HasColumnName("usuario");

                    b.HasKey("IdInstructor")
                        .HasName("PK__datosIns__C96115215D1A2FF5");

                    b.HasIndex("Usuario");

                    b.ToTable("datosInstructor");
                });

            modelBuilder.Entity("APIREST.Models.Detalle", b =>
                {
                    b.Property<int>("CodCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdCompra")
                        .HasColumnType("int")
                        .HasColumnName("idCompra");

                    b.Property<double?>("Precio")
                        .HasColumnType("float");

                    b.HasKey("CodCurso", "IdCompra")
                        .HasName("PK__Detalle__C648BBBF980591D1");

                    b.HasIndex("IdCompra");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("APIREST.Models.Estudiante", b =>
                {
                    b.Property<int>("IdEstudianes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idEstudianes")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<long?>("Nit")
                        .HasColumnType("bigint");

                    b.Property<long?>("NumTarjeta")
                        .HasColumnType("bigint");

                    b.HasKey("IdEstudianes")
                        .HasName("PK__estudian__AEFE45A63950CF98");

                    b.HasIndex("IdUsuario");

                    b.ToTable("estudiantes");
                });

            modelBuilder.Entity("APIREST.Models.Leccion", b =>
                {
                    b.Property<int>("IdLeccion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idLeccion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnlaceVideo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Enlace_video");

                    b.Property<int?>("IdCurso")
                        .HasColumnType("int")
                        .HasColumnName("idCurso");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLeccion")
                        .HasName("PK__Leccion__8916A411B9590120");

                    b.HasIndex("IdCurso");

                    b.ToTable("Leccion");
                });

            modelBuilder.Entity("APIREST.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Contraseña")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefono")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__645723A67F423AE4");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("APIREST.Models.Compra", b =>
                {
                    b.HasOne("APIREST.Models.Estudiante", "IdEstudianteNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdEstudiante")
                        .HasConstraintName("FK__Compra__idEstudi__06CD04F7");

                    b.Navigation("IdEstudianteNavigation");
                });

            modelBuilder.Entity("APIREST.Models.Curso", b =>
                {
                    b.HasOne("APIREST.Models.DatosInstructor", "IdInstructorNavigation")
                        .WithMany("Cursos")
                        .HasForeignKey("IdInstructor")
                        .HasConstraintName("FK__cursos__idInstru__5165187F")
                        .IsRequired();

                    b.Navigation("IdInstructorNavigation");
                });

            modelBuilder.Entity("APIREST.Models.DatosInstructor", b =>
                {
                    b.HasOne("APIREST.Models.Usuario", "UsuarioNavigation")
                        .WithMany("DatosInstructors")
                        .HasForeignKey("Usuario")
                        .HasConstraintName("FK__datosInst__usuar__5AEE82B9")
                        .IsRequired();

                    b.Navigation("UsuarioNavigation");
                });

            modelBuilder.Entity("APIREST.Models.Detalle", b =>
                {
                    b.HasOne("APIREST.Models.Curso", "CodCursoNavigation")
                        .WithMany("Detalles")
                        .HasForeignKey("CodCurso")
                        .HasConstraintName("FK__Detalle__CodCurs__0C85DE4D")
                        .IsRequired();

                    b.HasOne("APIREST.Models.Compra", "IdCompraNavigation")
                        .WithMany("Detalles")
                        .HasForeignKey("IdCompra")
                        .HasConstraintName("FK__Detalle__idCompr__0D7A0286")
                        .IsRequired();

                    b.Navigation("CodCursoNavigation");

                    b.Navigation("IdCompraNavigation");
                });

            modelBuilder.Entity("APIREST.Models.Estudiante", b =>
                {
                    b.HasOne("APIREST.Models.Usuario", "IdUsuarioNavigation")
                        .WithMany("Estudiantes")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK__estudiant__idUsu__6FE99F9F");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("APIREST.Models.Leccion", b =>
                {
                    b.HasOne("APIREST.Models.Curso", "IdCursoNavigation")
                        .WithMany("Leccions")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK__Leccion__idCurso__160F4887");

                    b.Navigation("IdCursoNavigation");
                });

            modelBuilder.Entity("APIREST.Models.Compra", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("APIREST.Models.Curso", b =>
                {
                    b.Navigation("Detalles");

                    b.Navigation("Leccions");
                });

            modelBuilder.Entity("APIREST.Models.DatosInstructor", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("APIREST.Models.Estudiante", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("APIREST.Models.Usuario", b =>
                {
                    b.Navigation("DatosInstructors");

                    b.Navigation("Estudiantes");
                });
#pragma warning restore 612, 618
        }
    }
}
