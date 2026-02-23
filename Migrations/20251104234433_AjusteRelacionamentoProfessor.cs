using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservaDeLaboratorioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteRelacionamentoProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Observacao",
                keyValue: null,
                column: "Observacao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Reservas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ProfessorId",
                table: "Reservas",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Professores_ProfessorId",
                table: "Reservas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Professores_ProfessorId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ProfessorId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Reservas",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
