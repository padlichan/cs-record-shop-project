using cs_record_shop_project.Models;
using cs_record_shop_project.Repositories;

namespace cs_record_shop_project.Services
{
    public class ArtistService : IArtistService
    {
        private IArtistRepository artistRepo;

        public ArtistService(IArtistRepository artistRepo)
        {
            this.artistRepo = artistRepo;
        }

        public bool IsValidArtist(int Id)
        {
            return artistRepo.IsValidArtist(Id);
        }

        public Artist? GetArtistById(int Id)
        {
            return artistRepo.GetArtistById(Id);
        }
    }
}
