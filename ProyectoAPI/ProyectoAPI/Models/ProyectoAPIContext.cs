using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoAPI.Models
{
    public partial class ProyectoAPIContext : DbContext
    {
        public ProyectoAPIContext()
        {
        }

        public ProyectoAPIContext(DbContextOptions<ProyectoAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuentaBancarium> CuentaBancaria { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<DatosInstructor> DatosInstructors { get; set; }
        public virtual DbSet<Leccion> Leccions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DF943KT;Database=ProyectoAPI;user=tito1;password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CuentaBancarium>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("PK__CuentaBa__BBC6DF3260D243A6");

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.NombreBanco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCuenta)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__8551ED05A3068602");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Duracion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_INSTRUCTOR");
            });

            modelBuilder.Entity<DatosInstructor>(entity =>
            {
                entity.HasKey(e => e.IdInstructor)
                    .HasName("PK__DatosIns__C9611521148B167E");

                entity.ToTable("DatosInstructor");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.Property(e => e.Certificacion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estudios)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ExperienciaLab)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.DatosInstructors)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CUENTA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.DatosInstructors)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO");
            });

            modelBuilder.Entity<Leccion>(entity =>
            {
                entity.HasKey(e => e.IdLeccion)
                    .HasName("PK__Leccion__8916A411DD511AA2");

                entity.ToTable("Leccion");

                entity.Property(e => e.IdLeccion).HasColumnName("idLeccion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Duracion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EnlaceVideo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Enlace_video");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Leccions)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CURSO");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6443A701A");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
