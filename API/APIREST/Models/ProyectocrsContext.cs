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

        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<DatosInstructor> DatosInstructors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Leccion> Leccions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IFKEU1D\\SQLEXPRESS;Database=Proyectocrs;user=sa;password=albin123;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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
