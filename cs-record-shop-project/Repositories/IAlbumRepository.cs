using cs_record_shop_project.Models;

namespace cs_record_shop_project.Repositories;

public interface IAlbumRepository
{
    List<Album> GetAllAlbums();
}