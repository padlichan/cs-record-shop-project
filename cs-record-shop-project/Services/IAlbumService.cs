using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services;

public interface IAlbumService
{
    ServiceResult<List<Album>> GetAllAlbums();
    ServiceResult<Album> AddAlbum(AlbumInputDto albumDto);    
    ServiceResult<Album> GetAlbumById(int id);
    ServiceResult<Album> UpdateAlbum(int id, AlbumInputDto albumDto);
    ServiceResult<Album> DeleteAlbum(int id);
}