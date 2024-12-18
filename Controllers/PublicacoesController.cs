using IRibeiroAPI.Infrastructure.Crosscutting.Enums;
using IRibeiroAPI.Infrastructure.Crosscutting.Exceptions;
using IRibeiroAPI.Infrastructure.Dto;
using IRibeiroAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IRibeiroAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicacoesController : BaseController
{
    private readonly IPublicationService _publicacaoService;
    private readonly ILogger<PublicacoesController> _logger;

    public PublicacoesController(IPublicationService publicacaoService, ILogger<PublicacoesController> logger)
    {
        _publicacaoService = publicacaoService;
        _logger = logger;
    }

    /// <summary>
    /// Obter as manchetes das notícias
    /// </summary>
    [HttpGet("GetHeadlines")]
    public async Task<APIResponse<List<HeadLineDto>>> GetHeadlines()
        => await HandleOperationAsync(() => _publicacaoService.GetHeadlines(), _logger);

    /// <summary>
    /// Obter os detalhes de uma publicação pela url
    /// </summary>
    [HttpGet("GetPublication(url)")]
    public async Task<APIResponse<PublicationTextDto>> GetPublication(string url)
        => await HandleOperationAsync(() => _publicacaoService.GetPublicationByURL(url), _logger);

    public async Task<APIResponse<List<PublicationDto>>> GetCurrent()
        => await HandleOperationAsync(() => _publicacaoService.GetCurrentPublications(), _logger);


}
