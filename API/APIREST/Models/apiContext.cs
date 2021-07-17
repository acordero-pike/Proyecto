using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIREST.Models
{
    public partial class apiContext : DbContext
    {
        public apiContext()
        {
        }

        public apiContext(DbContextOptions<apiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<DatosInstructor> DatosInstructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IFKEU1D\\SQLEXPRESS;Database=Proyectocrs;user=sa;password=albin123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__cursos__8551ED05916EEBE6");

                entity.ToTable("cursos");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Duracion)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("duracion");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__cursos__idInstru__267ABA7A");
            });

            modelBuilder.Entity<DatosInstructor>(entity =>
            {
                entity.HasKey(e => e.IdInstructor)
                    .HasName("PK__datosIns__C96115214F57C267");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
