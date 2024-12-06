using Microsoft.EntityFrameworkCore;
using IRibeiroAPI.Infrastructure.Context;
using IRibeiroAPI.Infrastructure.Crosscutting.Enums;
using IRibeiroAPI.Infrastructure.Crosscutting.Exceptions;
using IRibeiroAPI.Infrastructure.Crosscutting.Helpers;
using IRibeiroAPI.Infrastructure.Dto;

namespace IRibeiroAPI.Services;

public class PublicationService : IPublicationService
{
    private readonly AppDbContext _context;

    public PublicationService(AppDbContext context) => _context = context;
    
    public async Task<List<HeadLineDto>> GetHeadlines()
    {
        var publications = await _context.Publications
            .Where(_ => _.IsActive == true 
                        && _.PublicationTypeId == (int)EnumPublicationType.News)
            .Select(_ => new HeadLineDto
            {
                Title = _.Title,
                PublicationDate = _.PublicationDate.ToString("dd/MM/yyyy"),
                Source = _.Source
            })
            .ToListAsync();

        if (publications == null || !publications.Any())
        {
            throw new EntityNotFoundException(ResponseError.NotFound);
        }

        return publications;
    }

    public async Task<PublicationTextDto> GetPublicationByURL(string url)
    {
        var publication = await _context.Publications
            .Where(_ => _.Url == url)
            .Select(_ => new PublicationTextDto
            {
                ImageLink = _.ImageLink,
                Title = _.Title,
                PublicationText = _.PublicationText,
                PublicationDate = _.RevisionDate.HasValue
                                    ? _.RevisionDate.Value.ToString("dd/MM/yyyy")
                                    : _.PublicationDate.ToString("dd/MM/yyyy")
            })
            .FirstOrDefaultAsync();

        if (publication == null)
        {
            throw new EntityNotFoundException(ResponseError.NotFound);
        }

        return publication;
    }

    public async Task<List<PublicationDto>> GetCurrentPublications()
    {
        var publications = await _context.Publications
            .Where(_ => _.IsActive == true)
            .OrderByDescending(_ => _.PublicationDate)
            .Select(_ => new 
            {
                _.Title,
                _.Url,
                _.PublicationDate,
                _.Tags,
                PublicationTypeName = _.PublicationType.Name
            })
            .ToListAsync();

        if (publications == null || !publications.Any())
        {
            throw new EntityNotFoundException(ResponseError.NotFound);
        }

        return publications.Select(_ => new PublicationDto
        {
            Title = _.Title,
            URL = _.Url,
            ElapsedTime = TimeHelper.CalcularTempoPublicado(_.PublicationDate),
            Tags = _.Tags.Split(',').ToList(),
            PublicationType = _.PublicationTypeName
        }).ToList();            
    }
}
