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

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<DatosInstructor> DatosInstructors { get; set; }
        public virtual DbSet<Detalle> Detalles { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Leccion> Leccions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

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

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComentario)
                    .HasName("PK__Comentar__DDBEFBF903E90C70");

                entity.ToTable("Comentario");

                entity.Property(e => e.Pregunta).IsUnicode(false);

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.LeccionNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.Leccion)
                    .HasConstraintName("FK__Comentari__Lecci__3C34F16F");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__48B99DB7F3620682");

                entity.ToTable("Compra");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK__Compra__idEstudi__06CD04F7");
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
                    .HasName("PK__Detalle__C648BBBF980591D1");

                entity.ToTable("Detalle");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.HasOne(d => d.CodCursoNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.CodCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalle__CodCurs__0C85DE4D");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Detalles)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Detalle__idCompr__0D7A0286");
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

            modelBuilder.Entity<Leccion>(entity =>
            {
                entity.HasKey(e => e.IdLeccion)
                    .HasName("PK__Leccion__8916A411B9590120");

                entity.ToTable("Leccion");

                entity.Property(e => e.IdLeccion).HasColumnName("idLeccion");

                entity.Property(e => e.EnlaceVideo).HasColumnName("Enlace_video");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Leccions)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Leccion__idCurso__160F4887");
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
