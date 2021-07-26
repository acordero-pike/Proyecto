using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIREST.Models
{
    public partial class ProyectocrsContext : DbContext
    {
        public ProyectocrsContext()
        {
        }

        public ProyectocrsContext(DbContextOptions<ProyectocrsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<DatosInstructor> DatosInstructors { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Leccion> Leccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DF943KT;Database=Proyectocrs;user=tito1;password=1234;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__48B99DB7AFA4FE79");

                entity.ToTable("Compra");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Compra__idEstudi__72C60C4A");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__cursos__8551ED054066E96A");

                entity.ToTable("cursos");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cursos__idInstru__5165187F");
            });

            modelBuilder.Entity<DatosInstructor>(entity =>
            {
                entity.HasKey(e => e.IdInstructor)
                    .HasName("PK__datosIns__C96115215D1A2FF5");

                entity.ToTable("datosInstructor");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.Property(e => e.Certificacion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("certificacion");

                entity.Property(e => e.CuentaBancaria).HasColumnName("cuentaBancaria");

                entity.Property(e => e.Estudios)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("estudios");

                entity.Property(e => e.ExperienciaLab)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("experienciaLab");

                entity.Property(e => e.Usuario).HasColumnName("usuario");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.DatosInstructors)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__datosInst__usuar__5AEE82B9");
            });

            modelBuilder.Entity<Detalle>(entity =>
            {
                entity.HasKey(e => new { e.CodCurso, e.IdCompra })
                    .HasName("PK__Detalle__C648BBBF227C4716");

                entity.ToTable("Detalle");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.HasOne(d => d.CodCursoNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.CodCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalle__CodCurs__75A278F5");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalle__idCompr__76969D2E");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudianes)
                    .HasName("PK__estudian__AEFE45A63950CF98");

                entity.ToTable("estudiantes");

                entity.Property(e => e.IdEstudianes).HasColumnName("idEstudianes");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__estudiant__idUsu__6FE99F9F");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A67F423AE4");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
