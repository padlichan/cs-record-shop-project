using Azure.Core.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cs_record_shop_project.Models;

public class AlbumDto
{
    [Required]
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [Required]
    [JsonPropertyName("description")]
    public string Description { get; set; }

    public AlbumDto(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
