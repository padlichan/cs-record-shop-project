using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cs_record_shop_project.Models;

public class AlbumInputDtoBackup
{
    public AlbumInputDtoBackup(string title, string description, int year, int artistId)
    {
        Title = title;
        Description = description;
        Year = year;
        ArtistId = artistId;
    }

    [Required]
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [Required]
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [Required]
    [JsonPropertyName("year")]
    public int Year { get; set; }

    [Required]
    [JsonPropertyName("artistId")]
    public int ArtistId { get; set; }
}
