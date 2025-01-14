using cs_record_shop_project.Models;

namespace cs_record_shop_project.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private RecordShopDbContext recordShopDb;

    public AlbumRepository(RecordShopDbContext recordShopDb)
    {
        this.recordShopDb = recordShopDb;
    }
    public List<Album> GetAllAlbums()
    {
        return recordShopDb.Albums.ToList();
    }
}
