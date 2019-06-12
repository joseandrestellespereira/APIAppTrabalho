using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppTrabalho.Models
{
    public partial class escoladbContext : DbContext
    {
        public escoladbContext()
        {
        }

        public escoladbContext(DbContextOptions<escoladbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             optionsBuilder.UseNpgsql("Server=localhost;Database=escoladb;Port=5432;User Id=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("aluno");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTurma).HasColumnName("id_turma");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turma_aluno_fk");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turma");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasColumnName("curso")
                    .HasMaxLength(50);

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasColumnName("turno")
                    .HasMaxLength(20);
            });
        }
    }
}
