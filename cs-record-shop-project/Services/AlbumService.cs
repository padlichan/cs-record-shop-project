using cs_record_shop_project.Repositories;
using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services;

public class AlbumService : IAlbumService
{
    private IAlbumRepository albumRepo;

    public AlbumService(IAlbumRepository albumRepo)
    {
        this.albumRepo = albumRepo;
    }

    public List<Album> GetAllAlbums()
    {
        return albumRepo.GetAllAlbums();
    }

    public Album AddAlbum(AlbumDto albumDto)
    {
        return albumRepo.AddAlbum(albumDto);
    }

    public Album? GetAlbumById(int id)
    {
        return albumRepo.GetAlbumById(id);
    }
}
