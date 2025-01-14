using System.ComponentModel.DataAnnotations;

namespace cs_record_shop_project.Models;

public class Album
{
    private static int nextAlbumId = 1;
    public Album(string title, string description)
    {
        Id = nextAlbumId;
        nextAlbumId++;
        Title = title;
        Description = description;
    }

    public Album(AlbumDto albumDto)
    {
        Id = nextAlbumId;
        nextAlbumId++;
        Title = albumDto.Title;
        Description = albumDto.Description;
    }

    public int Id { get; init; }
    public string Title { get; set; }
    public string Description { get; set; }
}
