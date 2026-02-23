using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservaDeLaboratorioAPI.Migrations
{
    public partial class AjusteValidacaoReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove a constraint antiga
            migrationBuilder.Sql(@"
                ALTER TABLE Reservas 
                DROP CHECK IF EXISTS CK_Reserva_Periodo;
            ");

            // Cria uma nova regra mais flexível (>= 1 minuto)
            migrationBuilder.Sql(@"
                ALTER TABLE Reservas 
                ADD CONSTRAINT CK_Reserva_Periodo 
                CHECK (TIMESTAMPDIFF(MINUTE, DataInicio, DataFim) >= 1);
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Reservas 
                DROP CHECK IF EXISTS CK_Reserva_Periodo;
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE Reservas 
                ADD CONSTRAINT CK_Reserva_Periodo 
                CHECK (DataFim > DataInicio);
            ");
        }
    }
}
