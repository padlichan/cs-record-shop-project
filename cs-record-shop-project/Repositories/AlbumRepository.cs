using cs_record_shop_project.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_record_shop_project.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private RecordShopDbContext recordShopDb;

    public AlbumRepository(RecordShopDbContext recordShopDb)
    {
        this.recordShopDb = recordShopDb;
    }
    public List<Album> GetAllAlbums()
    {
        return recordShopDb.Albums.Include(a => a.Artist).ToList();
    }

    public Album AddAlbum(AlbumInputDto albumDto, int artistId)
    {
        Album albumToAdd = new Album(albumDto, artistId);
        recordShopDb.Albums.Add(albumToAdd);
        recordShopDb.SaveChanges();
        var addedAlbum = recordShopDb.Albums.Include(a => a.Artist).OrderBy(a => a.Id).Last();
        return addedAlbum;
    }

    public Album? GetAlbumById(int id)
    {
        return recordShopDb.Albums.Include(a => a.Artist).FirstOrDefault(album => album.Id == id);
    }

    public Album? UpdateAlbum(int id, AlbumInputDto albumDto, int artistId)
    {
        var albumToUpdate = recordShopDb.Albums.Include(a => a.Artist).FirstOrDefault(a => a.Id == id);
        if (albumToUpdate == null) return null;
        albumToUpdate.Title = albumDto.Title;
        albumToUpdate.Year = albumDto.Year;
        albumToUpdate.Description = albumDto.Description;
        albumToUpdate.ArtistId = artistId;
        recordShopDb.SaveChanges();
        return albumToUpdate;
    }

    public bool DeleteAlbum(int id)
    {
        var albumToDelete = recordShopDb.Albums.Include(a => a.Artist).FirstOrDefault(a => a.Id == id);
        if (albumToDelete == null) return false;
        recordShopDb.Albums.Remove(albumToDelete);
        recordShopDb.SaveChanges();
        return true;
    }
}
