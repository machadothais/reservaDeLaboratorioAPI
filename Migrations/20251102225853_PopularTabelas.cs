using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservaDeLaboratorioAPI.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ---------- LABORATÓRIOS ----------
            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "LaboratorioId", "Nome", "Capacidade" },
                values: new object[,]
                {
                    { 1, "Laboratório de Informática 1", 30 },
                    { 2, "Laboratório de Robótica", 25 }
                });

            // ---------- PROFESSORES ----------
            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorId", "Nome", "Email", "LaboratorioId" },
                values: new object[,]
                {
                    { 1, "Marcos Pereira", "marcos.pereira@ifsp.edu.br", 1 },
                    { 2, "Juliana Alves", "juliana.alves@ifsp.edu.br", 2 }
                });

            // ---------- TURMAS ----------
            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "TurmaId", "Nome", "QuantidadeAlunos", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Turma de Desenvolvimento Web", 28, 1 },
                    { 2, "Turma de Automação Industrial", 20, 2 }
                });

            // ---------- RESERVAS ----------
            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "ReservaId", "LaboratorioId", "TurmaId", "DataInicio", "DataFim", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 11, 5, 8, 0, 0), new DateTime(2025, 11, 5, 10, 0, 0), "Aula prática de HTML e CSS" },
                    { 2, 2, 2, new DateTime(2025, 11, 6, 14, 0, 0), new DateTime(2025, 11, 6, 16, 0, 0), "Testes com sensores e atuadores" }
                });

            // ---------- CONTATOS ----------
            migrationBuilder.InsertData(
                table: "Contatos",
                columns: new[] { "ContatoId", "Nome", "Email", "Mensagem" },
                values: new object[,]
                {
                    { 1, "Carlos Silva", "carlos.silva@ifsp.edu.br", "Olá! Gostaria de mais informações sobre a reserva de laboratórios." },
                    { 2, "Fernanda Souza", "fernanda.souza@ifsp.edu.br", "Tive um problema ao tentar reservar um laboratório, podem me ajudar?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover dados caso a migration seja revertida
            migrationBuilder.DeleteData(table: "Reservas", keyColumn: "ReservaId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Reservas", keyColumn: "ReservaId", keyValue: 2);

            migrationBuilder.DeleteData(table: "Turmas", keyColumn: "TurmaId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Turmas", keyColumn: "TurmaId", keyValue: 2);

            migrationBuilder.DeleteData(table: "Professores", keyColumn: "ProfessorId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Professores", keyColumn: "ProfessorId", keyValue: 2);

            migrationBuilder.DeleteData(table: "Laboratorios", keyColumn: "LaboratorioId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Laboratorios", keyColumn: "LaboratorioId", keyValue: 2);

            migrationBuilder.DeleteData(table: "Contatos", keyColumn: "ContatoId", keyValue: 1);
            migrationBuilder.DeleteData(table: "Contatos", keyColumn: "ContatoId", keyValue: 2);
        }
    }
}
