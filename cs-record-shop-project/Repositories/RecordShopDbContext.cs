using cs_record_shop_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_record_shop_project.Repositories;

public class RecordShopDbContext : DbContext
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Artist>().HasData
        (
            new Artist { Id = 1, Name = "Artist1" },
            new Artist { Id = 2, Name = "Artist2" },
            new Artist { Id = 3, Name = "Artist3" }
        );
    }
}
