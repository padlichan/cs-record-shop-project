using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services
{
    public interface IArtistService
    {
        Artist? GetArtistById(int Id);
        bool IsValidArtist(int Id);
    }
}