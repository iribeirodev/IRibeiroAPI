using IRibeiroAPI.Infrastructure.Dto;

namespace IRibeiroAPI.Services;

public interface IPublicacaoService
{
    /// <summary>
    /// Listagem de headlines
    /// </summary>
    Task<List<HeadLineDto>> ObterNoticias();    

    /// <summary>
    /// Obtém a publicação pela url passada como parâmetro
    /// </summary>
    Task<PublicationTextDto> ObterPublicacao(string url);
}
