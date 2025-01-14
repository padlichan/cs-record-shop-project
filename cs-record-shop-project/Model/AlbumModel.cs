namespace cs_record_shop_project.Model;

public class AlbumModel : IAlbumModel
{
    private RecordShopDbContext recordShopDb;

    public AlbumModel(RecordShopDbContext recordShopDb)
    {
        this.recordShopDb = recordShopDb;
    }
    public List<Album> GetAllAlbums()
    {
        return recordShopDb.Albums.ToList();
    }
}
