using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservaDeLaboratorioAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Laboratorios_LaboratorioId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Laboratorios_LaboratorioId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Laboratorios_LaboratorioId",
                table: "Professores",
                column: "LaboratorioId",
                principalTable: "Laboratorios",
                principalColumn: "LaboratorioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Laboratorios_LaboratorioId",
                table: "Reservas",
                column: "LaboratorioId",
                principalTable: "Laboratorios",
                principalColumn: "LaboratorioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Laboratorios_LaboratorioId",
                table: "Professores");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Laboratorios_LaboratorioId",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Laboratorios_LaboratorioId",
                table: "Professores",
                column: "LaboratorioId",
                principalTable: "Laboratorios",
                principalColumn: "LaboratorioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Laboratorios_LaboratorioId",
                table: "Reservas",
                column: "LaboratorioId",
                principalTable: "Laboratorios",
                principalColumn: "LaboratorioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Professores_ProfessorId",
                table: "Turmas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "ProfessorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
