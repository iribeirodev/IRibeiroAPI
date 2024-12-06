using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRibeiroAPI.Infrastructure.Models;

[Table("tipopublicacao")]
public class TipoPublicacao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }

    [Required]
    [MaxLength(30)] 
    public string Nome { get; set; } 
    
    public ICollection<Publicacao> Publicacoes { get; set; }
}
