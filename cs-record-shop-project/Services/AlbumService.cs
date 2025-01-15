using cs_record_shop_project.Repositories;
using cs_record_shop_project.Models;

namespace cs_record_shop_project.Services;

public class AlbumService : IAlbumService
{
    public const string NOT_FOUND_ERROR_MESSAGE = "Album not found.";
    public const string INVALID_ARTIST_ERROR_MESSAGE = "Invalid artist id.";
    private IAlbumRepository albumRepo;

    public AlbumService(IAlbumRepository albumRepo)
    {
        this.albumRepo = albumRepo;
    }

    public ServiceResult<List<Album>> GetAllAlbums()
    {
        return ServiceResult<List<Album>>.Success(albumRepo.GetAllAlbums());
    }

    public ServiceResult<Album> AddAlbum(AlbumInputDto albumDto)
    {
        //TO DO: Check if artist id is valid
        Album albumAdded = albumRepo.AddAlbum(albumDto);
        if (albumAdded == null) return ServiceResult<Album>.Error("Album cannot be added.");
        return ServiceResult<Album>.Success(albumAdded);

    }

    public ServiceResult<Album> GetAlbumById(int id)
    {
        Album? album = albumRepo.GetAlbumById(id);
        if (album == null) return ServiceResult<Album>.Error(NOT_FOUND_ERROR_MESSAGE);
        return ServiceResult<Album>.Success(album);
    }

    public ServiceResult<Album> UpdateAlbum(int id, AlbumInputDto albumDto)
    {
        var updatedAlbum = albumRepo.UpdateAlbum(id, albumDto);
        if (updatedAlbum == null) return ServiceResult<Album>.Error(NOT_FOUND_ERROR_MESSAGE);
        return ServiceResult<Album>.Success(updatedAlbum);
    }

    public ServiceResult<Album> DeleteAlbum(int id)
    {
        bool isDeleted = albumRepo.DeleteAlbum(id);
        if (isDeleted) return ServiceResult<Album>.SuccessNoData();
        return ServiceResult<Album>.Error(NOT_FOUND_ERROR_MESSAGE);
    }
}
