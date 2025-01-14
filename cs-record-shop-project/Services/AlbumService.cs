using cs_record_shop_project.Repositories;
using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services;

public class AlbumService : IAlbumService
{
    private IAlbumRepository albumModel;

    public AlbumService(IAlbumRepository albumModel)
    {
        this.albumModel = albumModel;
    }

    public List<Album> GetAllAlbums()
    {
        return albumModel.GetAllAlbums();
    }
}
