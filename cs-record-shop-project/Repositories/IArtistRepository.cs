using cs_record_shop_project.Models;

namespace cs_record_shop_project.Repositories
{
    public interface IArtistRepository
    {
        Artist? GetArtistById(int Id);

        Artist? GetArtistByName(string Name);
        bool IsValidArtist(int Id);
    }
}