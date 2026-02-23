using System.Text.Json;

namespace reservaDeLaboratorioAPI.Models;

public class ErrorsDetails
{
    public int Status { get; set; }
    public string? Message { get; set; }
    public string? Trace { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
