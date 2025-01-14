using cs_record_shop_project.Model;

namespace cs_record_shop_project.Service;

public class AlbumService : IAlbumService
{
    private IAlbumModel albumModel;

    public AlbumService(IAlbumModel albumModel)
    {
        this.albumModel = albumModel;
    }

    public List<Album> GetAllAlbums()
    {
        return albumModel.GetAllAlbums();
    }
}
