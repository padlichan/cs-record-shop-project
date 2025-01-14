using Microsoft.EntityFrameworkCore;

namespace cs_record_shop_project
{
    public class RecordShopDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public RecordShopDbContext(DbContextOptions<RecordShopDbContext> options) : base(options) { }
    }
}
