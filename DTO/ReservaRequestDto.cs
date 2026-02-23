
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace reservaDeLaboratorioAPI.DTO
{
    public class ReservaRequestDto
    {
        [Required]
        [JsonPropertyName("nomeLaboratorio")]
        public string NomeLaboratorio { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("nomeTurma")]
        public string NomeTurma { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("dataInicio")]
        public DateTime DataInicio { get; set; }

        [Required]
        [JsonPropertyName("dataFim")]
        public DateTime DataFim { get; set; }

        [JsonPropertyName("observacao")]
        public string? Observacao { get; set; }
    }
}
