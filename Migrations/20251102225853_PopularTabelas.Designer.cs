using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservaDeLaboratorioAPI.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ---------- LABORATÓRIOS ----------
            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "Nome", "Capacidade" },
                values: new object[,]
                {
                    { "Laboratório de Informática 1", 30 },
                    { "Laboratório de Robótica", 25 }
                });

            // ---------- PROFESSORES ----------
            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Nome", "Email", "LaboratorioId" },
                values: new object[,]
                {
                    { "Marcos Pereira", "marcos.pereira@ifsp.edu.br", 1 },
                    { "Juliana Alves", "juliana.alves@ifsp.edu.br", 2 }
                });

            // ---------- TURMAS ----------
            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Nome", "QuantidadeAlunos", "ProfessorId" },
                values: new object[,]
                {
                    { "Turma de Desenvolvimento Web", 28, 1 },
                    { "Turma de Automação Industrial", 20, 2 }
                });

            // ---------- RESERVAS ----------
            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "LaboratorioId", "TurmaId", "DataInicio", "DataFim", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 11, 5, 8, 0, 0), new DateTime(2025, 11, 5, 10, 0, 0), "Aula prática de HTML e CSS" },
                    { 2, 2, new DateTime(2025, 11, 6, 14, 0, 0), new DateTime(2025, 11, 6, 16, 0, 0), "Testes com sensores e atuadores" }
                });

            // ---------- CONTATOS ----------
            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "Nome", "Email", "Mensagem" },
                values: new object[,]
                {
                    { "Carlos Silva", "carlos.silva@ifsp.edu.br", "Olá! Gostaria de mais informações sobre a reserva de laboratórios." },
                    { "Fernanda Souza", "fernanda.souza@ifsp.edu.br", "Tive um problema ao tentar reservar um laboratório, podem me ajudar?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Reservas");
            migrationBuilder.Sql("DELETE FROM Turmas");
            migrationBuilder.Sql("DELETE FROM Professores");
            migrationBuilder.Sql("DELETE FROM Laboratorios");
            migrationBuilder.Sql("DELETE FROM Contatos");
        }
    }
}
