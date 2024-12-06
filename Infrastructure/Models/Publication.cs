using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRibeiroAPI.Infrastructure.Models;

[Table("publications")]
public class Publication
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("publication_type")]
    [Column("publicationtype_id")]
    public int PublicationTypeId { get; set; }

    [MaxLength(255)]
    [Column("title")]
    public string Title { get; set; }

    [MaxLength(150)]
    [Column("tags")]
    public string Tags { get; set; }

    [MaxLength(500)]
    [Column("url")]
    public string Url { get; set; }

    [Required]
    [Column("publication_date")]
    public DateTime PublicationDate { get; set; }

    [Column("revision_date")]
    public DateTime? RevisionDate { get; set; }

    [Required]
    [Column("is_active")]
    public bool IsActive { get; set; }

    [Required]
    [Column("publication_text")]
    public string PublicationText { get; set; }

    [MaxLength(255)]
    [Column("image_link")]
    public string ImageLink { get; set; }

    [MaxLength(100)]
    [Column("source")]
    public string Source { get; set; }

    public PublicationType PublicationType { get; set; }
}
