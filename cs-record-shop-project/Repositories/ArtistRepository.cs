using cs_record_shop_project.Models;
namespace cs_record_shop_project.Repositories;

public class ArtistRepository : IArtistRepository
{
    private RecordShopDbContext recordShopDb;

    public ArtistRepository(RecordShopDbContext recordShopDb)
    {
        this.recordShopDb = recordShopDb;
    }

    public bool IsValidArtist(int Id)
    {
        return recordShopDb.Artists.SingleOrDefault(a => a.Id == Id) != null;
    }

    public Artist? GetArtistById(int Id)
    {
        return recordShopDb.Artists.SingleOrDefault(a => a.Id == Id);
    }

    public Artist? GetArtistByName(string Name)
    {
        return recordShopDb.Artists.SingleOrDefault(a => a.Name == Name);
    }
}
