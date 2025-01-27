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
            new Artist(1, "Artist1"),
            new Artist(2, "Artist2"),
            new Artist(3, "Artist3")
        );
    }
}
