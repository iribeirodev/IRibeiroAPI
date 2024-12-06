using IRibeiroAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace IRibeiroAPI.Infrastructure.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }

    public DbSet<TipoPublicacao> TiposPublicacoes { get; set; }
    public DbSet<Publicacao> Publicacoes { get; set; }
}
