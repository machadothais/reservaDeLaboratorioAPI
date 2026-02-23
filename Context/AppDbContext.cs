using Microsoft.EntityFrameworkCore;
using reservaDeLaboratorioAPI.Controllers;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Laboratorio> Laboratorios => Set<Laboratorio>();
        public DbSet<Professor> Professores => Set<Professor>();
        public DbSet<Turma> Turmas => Set<Turma>();
        public DbSet<Reserva> Reservas => Set<Reserva>();
        public DbSet<Contato> Contatos => Set<Contato>();
       

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================================
            // 🔹 LABORATORIO -> PROFESSOR (1:N)
            // ================================
            modelBuilder.Entity<Professor>()
    .HasOne(p => p.Laboratorio)
    .WithMany(l => l.Professores)
    .HasForeignKey(p => p.LaboratorioId)
    .OnDelete(DeleteBehavior.Cascade);

            // Evita apagar laboratório com professores vinculados

            // ================================
            // 🔹 PROFESSOR -> TURMA (1:N)
            // ================================
            modelBuilder.Entity<Turma>()
                .HasOne(t => t.Professor)
                .WithMany(p => p.Turmas)
                .HasForeignKey(t => t.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
            // Evita apagar professor e deixar turmas órfãs

            // ================================
            // 🔹 TURMA -> RESERVA (1:N)
            // ================================
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Turma)
                .WithMany(t => t.Reservas)
                .HasForeignKey(r => r.TurmaId)
                .OnDelete(DeleteBehavior.Cascade);
            // Ao excluir uma turma, remove suas reservas

            // ================================
            // 🔹 LABORATORIO -> RESERVA (1:N)
            // ================================
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Laboratorio)
                .WithMany(l => l.Reservas)
                .HasForeignKey(r => r.LaboratorioId)
                .OnDelete(DeleteBehavior.Cascade);
            // Evita excluir laboratório com histórico de reservas

            // ================================
            // 🔹 CHECK CONSTRAINT: DataFim > DataInicio
            // ================================
            modelBuilder.Entity<Reserva>()
                .ToTable(tb => tb.HasCheckConstraint("CK_Reserva_Periodo", "[DataFim] > [DataInicio]"));

            // ================================
            // 🔹 ÍNDICES (melhoram performance nas buscas)
            // ================================
            modelBuilder.Entity<Reserva>()
                .HasIndex(r => new { r.LaboratorioId, r.DataInicio, r.DataFim });

            modelBuilder.Entity<Reserva>()
                .HasIndex(r => new { r.TurmaId, r.DataInicio });

            modelBuilder.Entity<Professor>()
                .HasIndex(p => p.Email)
                .IsUnique(false); // Pode ajustar para true se quiser email único

            modelBuilder.Entity<Laboratorio>()
                .HasIndex(l => l.Nome);

            modelBuilder.Entity<Turma>()
                .HasIndex(t => t.Nome);
        }
    }
}
