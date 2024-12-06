using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRibeiroAPI.Infrastructure.Models;

[Table("publicacoes")]
public class Publicacao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("TipoPublicacao")]
    [Column("id_tipopublicacao")]
    public int IdTipoPublicacao { get; set; }

    [MaxLength(255)]
    public string Titulo { get; set; }

    [MaxLength(150)]
    public string Tags { get; set; }

    [MaxLength(500)]
    public string Url { get; set; }

    [Required]
    [Column("data_publicacao")]
    public DateTime DataPublicacao { get; set; }

    [Column("data_revisao")]
    public DateTime? DataRevisao { get; set; }

    [Required]
    public bool Ativo { get; set; }

    [Required]
    public string Texto { get; set; }

    [MaxLength(255)]
    [Column("image_link")]
    public string ImageLink { get; set; }

    [MaxLength(100)]
    public string Fonte { get; set; }

    public TipoPublicacao TipoPublicacao { get; set; }
}
