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

                    b.ToTable("datosInstructor");
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
                    b.Navigation("Cursos");
                });
#pragma warning restore 612, 618
        }
    }
}