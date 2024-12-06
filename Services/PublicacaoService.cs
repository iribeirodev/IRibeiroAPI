using IRibeiroAPI.Infrastructure.Context;
using IRibeiroAPI.Infrastructure.Crosscutting.Enums;
using IRibeiroAPI.Infrastructure.Crosscutting.Exceptions;
using IRibeiroAPI.Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;

namespace IRibeiroAPI.Services;

public class PublicacaoService : IPublicacaoService
{
    private readonly AppDbContext _context;

    public PublicacaoService(AppDbContext context) => _context = context;
    
    public async Task<List<HeadLineDto>> ObterNoticias()
    {
        var publicacoes = await _context.Publicacoes
            .Include(tp => tp.TipoPublicacao)
            .Where(_ => _.Ativo == true 
                        && _.IdTipoPublicacao == (int)EnumTipoPublicacao.Noticia)
            .Select(_ => new HeadLineDto
            {
                Titulo = _.Titulo,
                DataPublicacao = _.DataPublicacao.ToString("dd/MM/yyyy"),
                Fonte = _.Fonte
            })
            .ToListAsync();

        if (publicacoes == null || publicacoes.Count == 0)
        {
            throw new EntityNotFoundException(ResponseError.NotFound);
        }

        return publicacoes;
    }

    public async Task<PublicationTextDto> ObterPublicacao(string url)
    {
        var publicacao = await _context.Publicacoes
            .Where(_ => _.Url == url)
            .Select(_ => new PublicationTextDto
            {
                ImageLink = _.ImageLink,
                Titulo = _.Titulo,
                Texto = _.Texto,
                DataPublicacao = _.DataRevisao.HasValue
                                    ? _.DataRevisao.Value.ToString("dd/MM/yyyy")
                                    : _.DataPublicacao.ToString("dd/MM/yyyy")
            })
            .FirstOrDefaultAsync();

        if (publicacao == null)
        {
            throw new EntityNotFoundException(ResponseError.NotFound);
        }

        return publicacao;
    }
}
