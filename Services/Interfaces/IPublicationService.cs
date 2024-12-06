using IRibeiroAPI.Infrastructure.Dto;

namespace IRibeiroAPI.Services;

public interface IPublicationService
{
    /// <summary>
    /// Listagem de headlines de notícias
    /// </summary>
    Task<List<HeadLineDto>> GetHeadlines();    

    /// <summary>
    /// Obtém a publicação pela url passada como parâmetro
    /// </summary>
    Task<PublicationTextDto> GetPublicationByURL(string url);

    /// <summary>
    /// Listagem de publicações ativas
    /// </summary>
    Task<List<PublicationDto>> GetCurrentPublications();
}
