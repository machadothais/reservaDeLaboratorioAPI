using reservaDeLaboratorioAPI.DTO;
using reservaDeLaboratorioAPI.Models;

namespace reservaDeLaboratorioAPI.Extensions;

public static class  ContatoExtensions
{
    public static ContatoResponseDto ToDto(this Contato contato)
    {
        if (contato == null)
            throw new ArgumentNullException(nameof(contato));
        return new ContatoResponseDto
        {
            Nome = contato.Nome,
            Email = contato.Email,
            
            Mensagem = contato.Mensagem
        };
    }
}
