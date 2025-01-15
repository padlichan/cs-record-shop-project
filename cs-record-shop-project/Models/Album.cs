using System.ComponentModel.DataAnnotations;

namespace cs_record_shop_project.Models;

public class Album
{
    [Key]
    public int Id { get; init; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public Artist Artist { get; set; }

    public Album(AlbumInputDto albumDto)
    {
        Title = albumDto.Title;
        Description = albumDto.Description;
        ArtistId = albumDto.ArtistId;
        Year = albumDto.Year;        
    }

    public Album(int id, string title, int artistId, int year, string description)
    {
        Id = id;
        Title = title;
        ArtistId = artistId;
        Year = year;
        Description = description;
    }
}
