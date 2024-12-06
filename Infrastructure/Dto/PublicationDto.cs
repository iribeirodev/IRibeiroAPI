using IRibeiroAPI.Infrastructure.Models;

namespace IRibeiroAPI.Infrastructure.Dto;

/// <summary>
/// Item da lista de publicações ativas
/// </summary>
public class PublicationDto
{
    public string Title { get; set; }
    public string URL { get; set; }
    public string ElapsedTime { get; set; }
    public List<string> Tags { get; set; }
    public string PublicationType { get; set; }
}
