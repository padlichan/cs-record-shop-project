using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cs_record_shop_project.Models;

public class AlbumInputDto
{
    public AlbumInputDto(string title, int year, string artistName, string description = "")
    {
        Title = title;
        Description = description;
        Year = year;
        ArtistName = artistName;
    }

    [Required]
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [Required]
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [Required]
    [JsonPropertyName("artistName")]
    public string ArtistName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }
}
