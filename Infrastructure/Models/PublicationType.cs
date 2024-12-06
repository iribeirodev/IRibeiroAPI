using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRibeiroAPI.Infrastructure.Models;

[Table("publication_type")]
public class PublicationType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }

    [Required]
    [MaxLength(30)] 
    [Column("name")]
    public string Name { get; set; } 
    
    public ICollection<Publication> Publications { get; set; }
}
