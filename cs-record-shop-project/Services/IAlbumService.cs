using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services;

public interface IAlbumService
{
    List<Album> GetAllAlbums();
    Album AddAlbum(AlbumDto albumDto);    
    Album? GetAlbumById(int id);
}