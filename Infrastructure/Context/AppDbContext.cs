using IRibeiroAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace IRibeiroAPI.Infrastructure.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}
    public DbSet<PublicationType> PublicationTypes { get; set; }
    public DbSet<Publication> Publications { get; set; }
}
