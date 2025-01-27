using cs_record_shop_project.Models;

namespace cs_record_shop_project.Repositories;

public interface IAlbumRepository
{
    List<Album> GetAllAlbums();
    Album AddAlbum(AlbumInputDto albumDto, int artistId);
    Album? GetAlbumById(int id);
    Album? UpdateAlbum(int id, AlbumInputDto albumDto, int artistId);
    bool DeleteAlbum(int id);
}