using cs_record_shop_project.Models;

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
        return recordShopDb.Albums.ToList();
    }

    public Album AddAlbum(AlbumDto albumDto)
    {
        recordShopDb.Albums.Add(new Album(albumDto));
        recordShopDb.SaveChanges();
        return recordShopDb.Albums.Last();
    }

    public Album? GetAlbumById(int id)
    {
        return recordShopDb.Albums.FirstOrDefault(album => album.Id == id);
    }

    public Album? UpdateAlbum(int id, AlbumDto albumDto)
    {
        var albumToUpdate = recordShopDb.Albums.FirstOrDefault(a => a.Id == id);
        if (albumToUpdate == null) return null;
        albumToUpdate.Title = albumDto.Title;
        albumToUpdate.Description = albumDto.Description;
        recordShopDb.SaveChanges();
        return albumToUpdate;
    }

    public bool DeleteAlbum(int id)
    {
        var albumToDelete = recordShopDb.Albums.FirstOrDefault(a =>a.Id == id); 
        if(albumToDelete == null) return false;
        recordShopDb.Albums.Remove(albumToDelete);
        recordShopDb.SaveChanges();
        return true;
    }
}
