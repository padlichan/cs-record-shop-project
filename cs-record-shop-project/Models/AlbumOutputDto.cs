using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cs_record_shop_project.Models;

public class AlbumOutputDto
{
    public AlbumOutputDto(int id, string title, string description, int year, string artistName)
    {
        Id = id;
        Title = title;
        Description = description;
        Year = year;
        ArtistName = artistName;
    }
    public AlbumOutputDto(Album album)
    {
        Id = album.Id;
        Title = album.Title;
        Description = album.Description;
        Year = album.Year;
        ArtistName = album.Artist?.Name ?? "Unknown";
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public string ArtistName { get; set; }
}
